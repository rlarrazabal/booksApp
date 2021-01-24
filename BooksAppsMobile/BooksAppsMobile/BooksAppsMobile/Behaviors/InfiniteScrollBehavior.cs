using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BooksAppsMobile.Behaviors
{
    public class InfiniteScrollBehavior:Behavior<ListView>
    {
        public ListView AssociatedObject { get; private set; }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(InfiniteScrollBehavior), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.ItemAppearing += OnItemAppearing;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.ItemAppearing -= OnItemAppearing;
            AssociatedObject = null;
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }

        private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var listview = (ListView)sender;
            if (!listview.IsRefreshing && Command != null && Command.CanExecute(e.Item))
            {
                Command.Execute(e.Item);
            }
        }

    }
}
