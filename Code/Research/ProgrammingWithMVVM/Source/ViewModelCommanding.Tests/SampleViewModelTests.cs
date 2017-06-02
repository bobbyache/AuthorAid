using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMDemo.ViewModel;

namespace ViewModelCommanding.Tests
{
    [TestClass]
    public class SampleViewModelTests
    {
        public SampleViewModelTests()
        {
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void test_property_notification()
        {
            SampleViewModel viewModel = new SampleViewModel();
            viewModel.PropertyChanged += viewModel_PropertyChanged;
            _ChangeNotification = false;
            viewModel.Name = "Miguel";

            Assert.IsTrue(_ChangeNotification, "Name property did not trigger change notification.");
        }

        bool _ChangeNotification = false;

        void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name")
                _ChangeNotification = true;
        }

        [TestMethod]
        public void test_simple_command_can_execute()
        {
            SampleViewModel viewModel = new SampleViewModel();
            viewModel.Name = "";

            Assert.IsTrue(viewModel.SimpleCommand.CanExecute(null) == false, "SimpleCommand should not be enabled.");

            viewModel.Name = "Miguel";

            Assert.IsTrue(viewModel.SimpleCommand.CanExecute(null) == true, "SimpleCommand should be enabled.");

        }
    }
}
