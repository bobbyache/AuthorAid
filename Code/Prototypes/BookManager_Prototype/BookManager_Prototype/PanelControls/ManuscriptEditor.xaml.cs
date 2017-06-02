using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using BookManager_Prototype.TypeExtensions;

namespace BookManager_Prototype.PanelControls
{
    /// <summary>
    /// Interaction logic for ManuscriptEditor.xaml
    /// </summary>
    public partial class ManuscriptEditor : UserControl
    {
        // RichTextBox File Load: http://www.rhyous.com/2011/08/01/loading-a-richtextbox-from-an-rtf-file-using-binding-or-a-richtextfile-control/
        // http://stackoverflow.com/questions/1367256/set-rtf-text-into-wpf-richtextbox-control

        public ManuscriptEditor()
        {
            InitializeComponent();
            DataObject.AddPastingHandler(editor, new DataObjectPastingEventHandler(OnPaste));
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            // cancels all formatting and pastes within.
            if (!e.SourceDataObject.GetDataPresent(DataFormats.Rtf, true))
                return;

            string rtf = e.SourceDataObject.GetData(DataFormats.Text) as string;
            InsertText(rtf);
            //editor.Document.ContentEnd.InsertTextInRun(rtf);
            //TextPointer startPos = editor.Selection.Start
            //    startPos
        }


        private void InsertText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            editor.BeginChange();
            if (editor.Selection.Text != string.Empty)
                editor.Selection.Text = string.Empty;

            TextPointer tp = editor.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
            editor.CaretPosition.InsertTextInRun(text);
            editor.CaretPosition = tp;
            editor.EndChange();
            Keyboard.Focus(editor);

            object obj = VisualTreeHelper.GetChild(editor.Document, 0);
            //editor.Document.
        }

        private DependencyObject FindVisualElement(DependencyObject obj, Type type)
        {
            return null;
        }

        /// <summary>
        /// It's already going to be assumed by you that the RichTextBox control or whatever
        /// editor control is out there will deal directly with the file. There will be no indirection
        /// through a Scene or SceneVersion object here.
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadEditor(string fileName)
        {
            // http://umaranis.wordpress.com/2010/11/29/save-and-load-richtextbox-content-in-wpf/
            TextRange t = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd); 
            FileStream file = new FileStream(fileName, FileMode.Open);
            //t.Load(file, System.Windows.DataFormats.XamlPackage);

            Stream stream = "rtf_text_back_to_stream".ToStream();
            t.Load(stream, System.Windows.DataFormats.Rtf); // and this is how we load it into the RTF document.
            
            
            file.Close();
        }

        /// <summary>
        /// It's already going to be assumed by you that the RichTextBox control or whatever
        /// editor control is out there will deal directly with the file. There will be no indirection
        /// through a Scene or SceneVersion object here.
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAs(string fileName)
        {
            // http://umaranis.wordpress.com/2010/11/29/save-and-load-richtextbox-content-in-wpf/

            TextRange t = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd); 
            FileStream file = new FileStream(fileName, FileMode.Create); 
            t.Save(file, System.Windows.DataFormats.XamlPackage);

            //t.

            //Stream testStream = new StreamReader(
            //t.Save(testStream, System.Windows.DataFormats.XamlPackage);


            file.Close();
        }

    }
}
