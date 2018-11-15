using Android.App;
using Android.Widget;
using Android.OS;
using Syncfusion.Android.DataForm;
using Android.Views;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Content;

namespace DataFormTouchGesture
{
    [Activity(Label = "DataFormTouchGesture", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SfDataForm dataForm = new SfDataForm(this);
            dataForm.DataObject = new ContactInfo();
            dataForm.SetBackgroundColor(Color.White);
            dataForm.LayoutManager = new DataFormLayoutManagerExt(dataForm,this);
            // Set our view from the "main" layout resource
            SetContentView(dataForm);
        }
    }

    public class ContactInfo
    {
        public string FirstName { get; set; }      
        public string LastName { get; set; }
        public string Address { get; set; }      
    }
    public class DataFormLayoutManagerExt : DataFormLayoutManager
    {
        Context context;
        public DataFormLayoutManagerExt(SfDataForm dataForm, Context _context) : base(dataForm)
        {
            context = _context;
        }
        protected override View GenerateViewForLabel(DataFormItem dataFormItem)
        {
            var label = base.GenerateViewForLabel(dataFormItem);        
            label.Touch += Label_Touch;
            return label;
        }

        private void Label_Touch(object sender, View.TouchEventArgs e)
        {
            Toast.MakeText(context, (sender as TextView).Text, ToastLength.Short).Show();
        }

        protected override void OnEditorCreated(DataFormItem dataFormItem, View editor)
        {
            base.OnEditorCreated(dataFormItem, editor);
            editor.Touch += Editor_Touch;
        }

        private void Editor_Touch(object sender, View.TouchEventArgs e)
        {
           // your code here
        }
    }
}

