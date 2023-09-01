using System.Windows;


namespace ArcGISMapSample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow 
    {
        //public Geometry FlagGeometry
        //{
        //    get { return (Geometry)GetValue(FlagGeometryProperty); }
        //    set { SetValue(FlagGeometryProperty, value); }
        //}

        //public static readonly DependencyProperty FlagGeometryProperty =
        //    DependencyProperty.Register("FlagGeometry", typeof(Geometry), typeof(MainWindow), new PropertyMetadata(null));



        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
            
        }

        

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WPFDevelopers.Controls.MessageBox.Show("是否退出当前系统?", "询问", MessageBoxButton.YesNo,
                MessageBoxImage.Question) != MessageBoxResult.OK)
                e.Cancel = true;
        }

       



        

        private void BtnAlarm_Click(object sender, RoutedEventArgs e)
        {
            //var layer = new FeatureLayer();
            
            //MyMapView.Map.OperationalLayers.Add(layer);
            //_polygonOverlay = new GraphicsOverlay();
            //_polygonOverlay.Id = "AlarmLayer";
            //MyMapView.GraphicsOverlays.Add(_polygonOverlay);
            //var pointSymbol = new SimpleMarkerSymbol
            //{
            //    Style = SimpleMarkerSymbolStyle.Circle,
            //    Color = System.Drawing.Color.Orange,
            //    Size = 10.0
            //};
            //var pointsGraphic = new Graphic()
            //{
            //    //11936805.6814874, Y=3752240.68058132
            //    Geometry = new MapPoint(11936805.6814874, 3752240.68058132),
            //    //Symbol = _window.Resources["animationSymbol"] as MarkerSymbol,
            //    Symbol = pointSymbol
            //};
            //_polygonOverlay.Graphics.Add(pointsGraphic);


            //var pointsGraphic2 = new Graphic()
            //{
            //    Geometry = new MapPoint(13188952.1121481, 4394850.41978244),
            //    Symbol = pointSymbol
            //};
            //_polygonOverlay.Graphics.Add(pointsGraphic2);

        }

    }

}
