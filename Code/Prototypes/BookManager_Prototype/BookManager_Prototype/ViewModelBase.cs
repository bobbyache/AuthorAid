using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

/*
 * http://stackoverflow.com/questions/5890212/wpf-mvvm-how-to-detect-if-a-view-is-dirty
One approach you can take is to leverage the IChangeTracking and INotifyPropertyChanged interfaces.

If you create an abstract base class that your view models inherit from (ViewModelBase) which implements the 
IChangeTracking and INotifyPropertyChanged interfaces, you can have your view model base attach to notification 
of property changes (in effect signaling that the view model has been modified) and which will set the IsChanged 
property to true to indicate that the view model is 'dirty'.

Using this approach, you are relying on property change notification via data binding to track changes and would reset 
the change tracking after any commits are made.

In the case you described you could handle the Unloaded or Closing event of your view to inspect the DataContext; 
and if the DataContext implements IChangeTracking you can use the IsChanged property to determine if any unaccepted changes have been made.
*/

namespace BookManager_Prototype
{
    /// <summary>
    /// Provides a base class for objects that support property change notification 
    /// and querying for changes and resetting of the changed status.
    /// </summary>
    public abstract class ViewModelBase : IChangeTracking, INotifyPropertyChanged
    {
        //========================================================
        //  Constructors
        //========================================================
        #region ViewModelBase()
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        protected ViewModelBase()
        {
            this.PropertyChanged += new PropertyChangedEventHandler(OnNotifiedOfPropertyChanged);
        }
        #endregion

        //========================================================
        //  Private Methods
        //========================================================
        #region OnNotifiedOfPropertyChanged(object sender, PropertyChangedEventArgs e)
        /// <summary>
        /// Handles the <see cref="INotifyPropertyChanged.PropertyChanged"/> event for this object.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="PropertyChangedEventArgs"/> that contains the event data.</param>
        private void OnNotifiedOfPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e != null && !String.Equals(e.PropertyName, "IsChanged", StringComparison.Ordinal))
            {
                this.IsChanged = true;
            }
        }
        #endregion

        //========================================================
        //  IChangeTracking Implementation
        //========================================================
        #region IsChanged
        /// <summary>
        /// Gets the object's changed status.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the object’s content has changed since the last call to <see cref="AcceptChanges()"/>; otherwise, <see langword="false"/>. 
        /// The initial value is <see langword="false"/>.
        /// </value>
        public bool IsChanged
        {
            get
            {
                lock (_notifyingObjectIsChangedSyncRoot)
                {
                    return _notifyingObjectIsChanged;
                }
            }

            protected set
            {
                lock (_notifyingObjectIsChangedSyncRoot)
                {
                    if (!Boolean.Equals(_notifyingObjectIsChanged, value))
                    {
                        _notifyingObjectIsChanged = value;

                        this.OnPropertyChanged("IsChanged");
                    }
                }
            }
        }
        private bool _notifyingObjectIsChanged;
        private readonly object _notifyingObjectIsChangedSyncRoot = new Object();
        #endregion

        #region AcceptChanges()
        /// <summary>
        /// Resets the object’s state to unchanged by accepting the modifications.
        /// </summary>
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
        #endregion

        //========================================================
        //  INotifyPropertyChanged Implementation
        //========================================================
        #region PropertyChanged
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region OnPropertyChanged(PropertyChangedEventArgs e)
        /// <summary>
        /// Raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">A <see cref="PropertyChangedEventArgs"/> that provides data for the event.</param>
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region OnPropertyChanged(string propertyName)
        /// <summary>
        /// Raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event for the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The <see cref="MemberInfo.Name"/> of the property whose value has changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region OnPropertyChanged(params string[] propertyNames)
        /// <summary>
        /// Raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event for the specified <paramref name="propertyNames"/>.
        /// </summary>
        /// <param name="propertyNames">An <see cref="Array"/> of <see cref="String"/> objects that contains the names of the properties whose values have changed.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="propertyNames"/> is a <see langword="null"/> reference (Nothing in Visual Basic).</exception>
        protected void OnPropertyChanged(params string[] propertyNames)
        {
            if (propertyNames == null)
            {
                throw new ArgumentNullException("propertyNames");
            }

            foreach (var propertyName in propertyNames)
            {
                this.OnPropertyChanged(propertyName);
            }
        }
        #endregion
    }
}
