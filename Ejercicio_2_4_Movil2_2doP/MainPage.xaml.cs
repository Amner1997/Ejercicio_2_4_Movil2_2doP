using Ejercicio_2_4_Movil2_2doP.Models;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio_2_4_Movil2_2doP
{
    public partial class MainPage : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            Stream image = await PadView.GetImageStreamAsync(SignatureImageFormat.Png);
            byte[] imageBytes = null;

            if (image != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }
            }

            var signature = new Signatures
            {
                FirmaDigital = imageBytes,
                Descripcion = descripcion.Text
            };

            if (await App.Instancia.AddPhoto(signature) > 0)
            {
                await DisplayAlert("Aviso", "Firma guardada correctamente", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "No se ha podido guardar la firma", "Ok");
            }
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            PadView.Clear();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageListaFirmas());
        }
    }
}
