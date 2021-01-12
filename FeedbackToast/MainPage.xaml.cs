using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FeedbackToast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var builder = new ToastContentBuilder()
                .AddText("How likely are you to recommend this version of Word to others, if asked?")
                .AddVisualChild(new AdaptiveGroup()
                {
                    Children =
                    {
                        new AdaptiveSubgroup()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "1 - Not at all likely"
                                },

                                new AdaptiveText()
                                {
                                    Text = "5 - Extremely likely"
                                }
                            }
                        }
                    }
                });

            for (int i = 1; i <= 5; i++)
            {
                builder.AddButton(new ToastButton()
                    .SetContent(i.ToString())
                    .SetImageUri(new Uri("ms-appx:///Assets/radio.png"))
                    .AddArgument("rating", i)
                    .SetBackgroundActivation()
                    .SetAfterActivationBehavior(ToastAfterActivationBehavior.PendingUpdate));
            }

            builder.Show(toast =>
            {
                toast.Tag = "feedback";
            });
        }
    }
}
