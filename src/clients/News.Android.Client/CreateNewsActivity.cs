using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using News.Client.Models;
using Newtonsoft.Json;

namespace News.Client
{
    [Activity(Label = "Create New News")]
    public class CreateNewsActivity : Activity
    {
        private static HttpClient httpClient = new HttpClient();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateNews);

            var btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Click += SendPostReq;
        }

        private void SendPostReq(object sender, System.EventArgs e)
        {
            var title = FindViewById<EditText>(Resource.Id.editText1);
            var content = FindViewById<EditText>(Resource.Id.editText2);

            var model = new NewsBindingModel
            {
                Title = title.Text,
                Content = content.Text
            };

            try
            {
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(model),
                    Encoding.UTF8,
                    "application/json");

                var response = httpClient.PostAsync("http://10.0.2.2:56624/api/News", stringContent)
                    .GetAwaiter()
                    .GetResult();


                if (response.IsSuccessStatusCode)
                {
                    OpenSuccessDialog();
                }
                else
                {
                    var result = response.Content
                        .ReadAsStringAsync()
                        .GetAwaiter()
                        .GetResult();

                    var messageModel = JsonConvert.DeserializeObject<MessageModel>(result);

                    OpenUnSuccessDialog(messageModel.Messages.First());
                }

                title.Text = string.Empty;
                content.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void OpenSuccessDialog()
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog dialog = builder.Create();
            dialog.SetTitle("News was successfully created.");
            dialog.SetMessage("Back to home page?");
            dialog.SetButton("OK", (c, ev) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            });

            dialog.SetButton2("Cancel", (c, ev) =>
            {

            });

            dialog.Show();
        }

        private void OpenUnSuccessDialog(string msg)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog dialog = builder.Create();
            dialog.SetTitle("News did not create successfully.");
            dialog.SetMessage("Message: " + msg + " Call somebody for a help?");
            dialog.SetButton("OK", (c, ev) =>
            {
                var uri = Android.Net.Uri.Parse("content://contacts/people/");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);

            });

            dialog.SetButton2("Cancel", (c, ev) =>
            {});

            dialog.Show();
        }
    }
}