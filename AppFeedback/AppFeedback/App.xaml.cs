﻿namespace AppFeedback
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new Views.ListagemFeedbackView());
            MainPage = new AppShell();

        }
    }
}
