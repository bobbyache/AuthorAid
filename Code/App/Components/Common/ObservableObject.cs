//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Runtime.Serialization;

//namespace CygX1.AuthorAid.CommonKernel
//{
//    // https://github.com/ascendedguard/Ascend.MvvmFoundation/blob/master/ObservableObject.cs

//    [DataContract]
//    /// <summary>
//    /// This is the abstract base class for any object that provides property change notifications.  
//    /// </summary>
//    public abstract class ObservableObject : INotifyPropertyChanged
//    {
//        /// <summary>
//        /// Raised when a property on this object has a new value.
//        /// </summary>
//        public event PropertyChangedEventHandler PropertyChanged;

//        /// <summary>
//        /// Gets a value indicating whether an exception is thrown, or if a Debug.Fail() is used
//        /// when an invalid property name is passed to the VerifyPropertyName method.
//        /// The default value is false, but subclasses used by unit tests might 
//        /// override this property's getter to return true.
//        /// </summary>
//        [IgnoreDataMember]
//        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }


//        /// <summary>
//        /// Warns the developer if this object does not have
//        /// a public property with the specified name. This 
//        /// method does not exist in a Release build.
//        /// </summary>
//        /// <param name="propertyName"> The property name. </param>
//        [Conditional("DEBUG")]
//        [DebuggerStepThrough]
//        public void VerifyPropertyName(string propertyName)
//        {
//            // If you raise PropertyChanged and do not specify a property name,
//            // all properties on the object are considered to be changed by the binding system.
//            if (string.IsNullOrEmpty(propertyName))
//            {
//                return;
//            }


//            // Verify that the property name matches a real,  
//            // public, instance property on this object.
//            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
//            {
//                string msg = "Invalid property name: " + propertyName;


//                if (this.ThrowOnInvalidPropertyName)
//                {
//                    throw new ArgumentException(msg);
//                }

//                Debug.Fail(msg);
//            }
//        }


//        /// <summary>
//        /// Raises this object's PropertyChanged event.
//        /// </summary>
//        /// <param name="propertyName">The property that has a new value.</param>
//        protected void RaisePropertyChanged(string propertyName)
//        {
//            this.VerifyPropertyName(propertyName);


//            PropertyChangedEventHandler handler = this.PropertyChanged;
//            if (handler != null)
//            {
//                var e = new PropertyChangedEventArgs(propertyName);
//                handler(this, e);
//            }
//        }
//    }
//}
