using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;

namespace Esa
{   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>    
    public partial class MainWindow : Window
    {
        HttpClient webClient = new HttpClient();
        string valinta = "";
        public MainWindow()
        {
            InitializeComponent();
            LoadItems();            
        }
        
        //Haetaan JSON ja deserialisoidaan, jonka jälkeen näytetään data listboxissa ja buttosella datagridissä.
        private async void LoadItems()
        {            
            try
            {
                if (valinta == "") 
                {
                    Uri uri = new Uri("http://gis.vantaa.fi/rest/tyopaikat/v1/");
                    HttpResponseMessage response = await webClient.GetAsync(uri);
                    string jsonString = await response.Content.ReadAsStringAsync();
                    List<RootObject> ammattialat = JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
                    listBox.ItemsSource = ammattialat;
                }
                else
                {
                    Uri uri = new Uri("http://gis.vantaa.fi/rest/tyopaikat/v1/" + valinta);
                    HttpResponseMessage response = await webClient.GetAsync(uri);
                    string jsonString = await response.Content.ReadAsStringAsync();
                    List<Ammattiala> työpaikka = JsonConvert.DeserializeObject<List<Ammattiala>>(jsonString);
                    dgResponse.ItemsSource = työpaikka;
                }               
            }
            catch (Exception ex)
            {
                debug.Content = ex.Message.ToString();
            }
        }
                
        private void button_Click(object sender, RoutedEventArgs e)
        {
            valinta = listBox.SelectedItem.ToString();
            LoadItems();
            if (debug.Content != null)
            {
                debug.Content = null;
            }            
        }

        private void btnOhje_Click(object sender, RoutedEventArgs e)
        {
            debug.Content = "Valitse ammattiala vasemmalta ja paina valitse -painiketta";
        }
    }
} 