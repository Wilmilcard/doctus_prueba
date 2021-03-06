﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Doctus_Prueba.Models;
using Doctus_Prueba.ViewModels;

namespace Doctus_Prueba.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Tip
            {
                Titulo = "Prueba",
                Descripcion = "Prueba de cargue."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void SelectedTip(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage(viewModel.Item)));
        }
    }
}