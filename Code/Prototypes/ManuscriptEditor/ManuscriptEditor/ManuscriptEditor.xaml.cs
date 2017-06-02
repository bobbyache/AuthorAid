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

namespace WpfManuscriptEditor
{
    /// <summary>
    /// Interaction logic for ManuscriptEditor.xaml
    /// </summary>
    public partial class ManuscriptEditor : UserControl
    {
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
            e.CancelCommand();
            string rtf = e.SourceDataObject.GetData(DataFormats.Text) as string;
            InsertText(rtf);

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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    IEnumerable<Paragraph> paragraphs = editor.Document.Blocks.Where(block => block is Paragraph).OfType<Paragraph>();
        //    MessageBox.Show(string.Format("Paragraph count: {0}", paragraphs.Count()));

        //        //paragraph.TextIndent = 30;
        //}
    }
}
