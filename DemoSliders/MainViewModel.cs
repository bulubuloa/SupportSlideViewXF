using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoSliders
{
    public class MainViewModel : BindableObject
    {
        private List<string> _ImageItems;
        public List<string> ImageItems
        {
            get => _ImageItems;
            set
            {
                _ImageItems = value;
                OnPropertyChanged();
            }
        }

        private List<View> _ViewItems;
        public List<View> ViewItems
        {
            get => _ViewItems;
            set
            {
                _ViewItems = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            //Task.Delay(4000).ContinueWith(delegate {
            //    ImageItems = new List<string>()
            //    {
            //        "https://brand.campaign.adidas.com/Images/originals-fw18-dragonball-mh-d-v1_tcm66-283071.jpg?locale=en_US&device=mobile&version=6",
            //        "https://i.kinja-img.com/gawker-media/image/upload/s--bjOlN1Qv--/c_scale,f_auto,fl_progressive,q_80,w_800/iar4q55hka6jjpzelpy8.jpg",
            //        "https://assets1.ignimgs.com/2018/08/30/dbzvillains-blogroll-1535589058116_1280w.jpg",
            //        "https://static0.srcdn.com/wordpress/wp-content/uploads/2018/07/Dragon-Ball-Ultra-Instinct-Goku-Kamehameha.jpg",
            //        "https://thedaoofdragonball.com/wp-content/uploads/2012/10/dragon-ball-culture-6-available-home-print.png"
            //    };
            //});

            Task.Delay(2000).ContinueWith(delegate {
                ViewItems = new List<View>()
                {
                    new ContentView()
                    {
                        BackgroundColor = Color.Accent
                    },
                    new ContentView()
                    {
                        BackgroundColor = Color.Blue
                    },
                    new ContentView()
                    {
                        BackgroundColor = Color.Gray
                    },
                    new ContentView()
                    {
                        BackgroundColor = Color.Green
                    }
                    ,new ContentView()
                    {
                        BackgroundColor = Color.Red
                    }
                };
            });
        }
    }
}