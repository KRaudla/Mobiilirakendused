using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Facebook_view.CategoryRecyclerView
{


    public class Category
    {
        public string Name { get; set; }
        public int ImageId { get; set; }


        public List<Category> GenerateDummyData()
        {
            var categories = new List<Category>();

            var category1 = new Category();
            category1.Name = "Toit";
            category1.ImageId = Resource.Drawable.toit48;
            categories.Add(category1);

            var category2 = new Category();
            category2.Name = "Kingitused";
            category2.ImageId = Resource.Drawable.kingitused48;
            categories.Add(category2);

            var category3 = new Category();
            category3.Name = "Meelelahutus";
            category3.ImageId = Resource.Drawable.meelelahutus48;
            categories.Add(category3);

            var category4 = new Category();
            category4.Name = "Kodu";
            category4.ImageId = Resource.Drawable.kodu48;
            categories.Add(category4);

            var category5 = new Category();
            category5.Name = "Auto";
            category5.ImageId = Resource.Drawable.auto48;
            categories.Add(category5);

            var category6 = new Category();
            category6.Name = "Tervis";
            category6.ImageId = Resource.Drawable.tervis48;
            categories.Add(category6);

            var category7 = new Category();
            category7.Name = "Ilu";
            category7.ImageId = Resource.Drawable.ilu48;
            categories.Add(category7);

            var category8 = new Category();
            category8.Name = "Muu";
            category8.ImageId = Resource.Drawable.muu48;
            categories.Add(category8);

            return categories;

        }
    }
}