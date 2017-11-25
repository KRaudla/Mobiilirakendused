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
using Exercises;

namespace Excrcises
{
    [Activity(Label = "listview_activity")]
    public class listview_activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.listviewlayout);//call layout
            var listView = FindViewById<ListView>(Resource.Id.listview1);//define list object


            var carList = GenerateCars();

            listView.Adapter = new CustomAdapter(this, carList);

            //tap listener to listview
            listView.ItemClick += ListView_ItemClick; 
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.Widget.Toast.MakeText(this,"Vajutasid",Android.Widget.ToastLength.Short).Show();
        }

        private List<Car> GenerateCars()
        {
            var listOfCars = new List<Car>();
            var car1 = new Car();
            car1.Name = "Ferrari";
            car1.Kw = 325;
            car1.Model = "Enzo";
            car1.ImageId = Resource.Drawable.car;
            listOfCars.Add(car1);
            var car2 = new Car();
            car2.Name = "Lamborghini";
            car2.Kw = 124;
            car2.Model = "Something";
            car2.ImageId = Resource.Drawable.car;
            listOfCars.Add(car2);
            var car3 = new Car();
            car3.Name = "BMW";
            car3.Kw = 346;
            car3.Model = "M3";
            car3.ImageId = Resource.Drawable.car;
            listOfCars.Add(car3);
            var car4 = new Car();
            car4.Name = "Volkswagen";
            car4.Kw = 2;
            car4.Model = "Passat";
            listOfCars.Add(car4);
            var car5 = new Car();
            car5.Name = "Lada";
            car5.Kw = 34;
            car5.Model = "Samara";
            listOfCars.Add(car5);
            var car6 = new Car();
            car6.Name = "Opel";
            car6.Kw = 63;
            car6.Model = "Astra";
            listOfCars.Add(car6);
            var car7 = new Car();
            car7.Name = "Skoda";
            car7.Kw = 25;
            car7.Model = "Octavia";
            listOfCars.Add(car7);
            var car8 = new Car();
            car8.Name = "Alfa";
            car8.Kw = 78;
            car8.Model = "Romeo";
            listOfCars.Add(car8);
            var car9 = new Car();
            car9.Name = "Jaguar";
            car9.Kw = 700;
            car9.Model = "XZ";
            listOfCars.Add(car9);
            return listOfCars;
        }
    }
}