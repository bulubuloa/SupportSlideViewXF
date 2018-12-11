using System;
using System.Collections.Generic;
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

        public MainViewModel()
        {
            ImageItems = new List<string>()
            {
                "https://g.foolcdn.com/image/?url=https%3A%2F%2Fg.foolcdn.com%2Feditorial%2Fimages%2F488289%2Fpile-of-100-dollar-bills_gettyimages-452970107.jpg&w=700&op=resize",
                "https://www.gannett-cdn.com/-mm-/3b8b0abcb585d9841e5193c3d072eed1e5ce62bc/c=0-30-580-356/local/-/media/2018/02/24/USATODAY/usatsports/large-pile-of-hundred-dollar-bills-cash-money-savings-rich_large.jpg?width=3200&height=1680&fit=crop",
                "https://www.washingtonpost.com/resizer/WjcCKKASaRe_9I1CbmHTaqHyt4I=/480x0/arc-anglerfish-washpost-prod-washpost.s3.amazonaws.com/public/62BEHGTVEQI6LDMTBLZRP3KYZE.jpg"
            };
        }
    }
}