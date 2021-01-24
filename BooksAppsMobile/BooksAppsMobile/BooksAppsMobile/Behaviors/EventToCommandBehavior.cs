using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BooksAppsMobile.Behaviors
{
    public class EventToCommandBehavior : Behavior<View>
    {
        View view;
        Delegate eventHandler;
        public string EventName { get => (string)GetValue(EventNameProperty); set => SetValue(EventNameProperty, value); }
        public readonly static BindableProperty EventNameProperty = BindableProperty.Create
            (nameof(EventName), typeof(string), typeof(EventToCommandBehavior), string.Empty);
        public ICommand Command { get => (ICommand)GetValue(CommandProperty); set => SetValue(CommandProperty, value); }
        public readonly static BindableProperty CommandProperty = BindableProperty.Create
            (nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior), null);

        public IValueConverter Converter { get => (IValueConverter)GetValue(ConverterProperty); set => SetValue(ConverterProperty, value); }
        public readonly static BindableProperty ConverterProperty = BindableProperty.Create
            (nameof(Converter), typeof(IValueConverter), typeof(EventToCommandBehavior), null);
        public object CommandParameter { get => GetValue(CommandParameterProperty); set => SetValue(CommandParameterProperty, value); }
        public readonly static BindableProperty CommandParameterProperty = BindableProperty.Create
            (nameof(CommandParameter), typeof(object), typeof(EventToCommandBehavior), null);

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            view = (View)bindable;
            RegisterEvent(EventName, bindable);
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            DeregisterEvent(EventName, bindable);
            view = null;
            base.OnDetachingFrom(bindable);
        }

        public void RegisterEvent(string eventName, BindableObject bindable)
        {
            if (string.IsNullOrWhiteSpace(eventName))
            {
                return;
            }
            var eventInfo = bindable.GetType().GetRuntimeEvent(eventName);
            if (eventInfo == null)
            {
                return;
            }
            var methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod(nameof(OnEvent));
            eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(bindable, eventHandler);
        }

        public void DeregisterEvent(string eventName, BindableObject bindable)
        {
            if (string.IsNullOrWhiteSpace(eventName))
            {
                return;
            }
            if (eventHandler == null)
            {
                return;
            }
            var eventInfo = bindable.GetType().GetRuntimeEvent(eventName);
            if (eventInfo == null)
            {
                return;
            }
            eventInfo.RemoveEventHandler(bindable, eventHandler);
            eventHandler = null;
        }

        public void OnEvent(object sender, object eventArgs)
        {
            if (Command == null)
            {
                return;
            }
            var parameters = eventArgs;
            if (CommandParameter != null)
            {
                parameters = CommandParameter;
            }
            else if (Converter != null)
            {
                parameters = Converter.Convert(eventArgs, typeof(object), null, null);
            }
            if (Command.CanExecute(parameters) == true)
            {
                Command.Execute(parameters);
            }
        }

        public void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (EventToCommandBehavior)bindable;
            if (behavior.view == null)
            {
                return;
            }
            behavior.DeregisterEvent((string)oldValue, behavior.view);
            behavior.RegisterEvent((string)newValue, behavior.view);
        }
    }
}
