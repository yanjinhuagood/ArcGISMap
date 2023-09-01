using ArcGISMapSample.Helpers;
using ArcGISMapSample.MapService;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using Microsoft.Expression.Drawing.Core;
using System;
using System.Windows;
using System.Windows.Controls;



namespace ArcGISMapSample.Views
{
    /// <summary>
    /// MapControl.xaml 的交互逻辑
    /// </summary>
    public partial class MapControl : UserControl
    {


        public Map CurrentMap
        {
            get { return (Map)GetValue(CurrentMapProperty); }
            set { SetValue(CurrentMapProperty, value); }
        }
        public static readonly DependencyProperty CurrentMapProperty =
            DependencyProperty.Register("CurrentMap", typeof(Map), typeof(MapControl), new PropertyMetadata(null));

        private GraphicsOverlay _polygonOverlay;
        public MapEnum SelectMap
        {
            get { return (MapEnum)GetValue(SelectMapProperty); }
            set { SetValue(SelectMapProperty, value); }
        }

        public static readonly DependencyProperty SelectMapProperty =
            DependencyProperty.Register("SelectMap", typeof(MapEnum), typeof(MapControl), new PropertyMetadata(MapEnum.AMap, OnSelectMapChanged));

        private static void OnSelectMapChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var mapControl = d as MapControl;
            if (mapControl == null) return;
            mapControl.ToggleMaps();
        }
        public MapControl()
        {
            InitializeComponent();
            Loaded += delegate
            {
                CurrentMap = new Map();
                Envelope initialLocation = new Envelope(6268403.88422598, 7100416.45414403, 17821754.9183527, 2472946.94180151, SpatialReferences.WebMercator);
                var viewPoint = new Viewpoint(initialLocation);
                CurrentMap.InitialViewpoint = viewPoint;
                MyMapView.GeoViewTapped += OnMapViewTapped;
                MyMapView.Map = CurrentMap;
                //MyMapView.MouseDown += MyMapView_MouseDown;
                ToggleMaps();
                //MapPoint[X=12957324.7749284, Y=4852733.83604208, Wkid=3857]
                //FlagGeometry = new MapPoint(12957324.7749284, 4852733.83604208, SpatialReferences.WebMercator);
            };
        }
        private async void OnMapViewTapped(object sender, GeoViewInputEventArgs e)
        {
            double tolerance = 10d;
            int maximumResults = 1;
            bool onlyReturnPopups = false;

            try
            {
                IdentifyGraphicsOverlayResult identifyResults = await MyMapView.IdentifyGraphicsOverlayAsync(
                    _polygonOverlay,
                    e.Position,
                    tolerance,
                    onlyReturnPopups,
                    maximumResults);

                if (identifyResults.Graphics.Count > 0)
                {
                    identifyResults.Graphics.ForEach(x =>
                    {
                        if (!x.IsSelected)
                            x.IsSelected = true;
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }
        void ToggleMaps()
        {
            CurrentMap.OperationalLayers.Clear();
            ServiceImageTiledLayer tiledLayer = default;
            switch (SelectMap)
            {
                case MapEnum.AMap:
                    tiledLayer = new AMapLayer();
                    break;
                case MapEnum.BaiduMap:
                    tiledLayer = new BaiduMapLayer();
                    break;
                case MapEnum.TencentMap:
                    tiledLayer = new TencentMapLayer();
                    break;
                default:
                    break;
            }
            if (tiledLayer == default) return;
            tiledLayer.Id = "MapLayer";
            CurrentMap.OperationalLayers.Add(tiledLayer);

        }



        private void MyMapView_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //var p = MyMapView.PointToScreen(e.GetPosition(MyMapView));
            //var p2 = MyMapView.ScreenToLocation(e.GetPosition(MyMapView));
            //Console.WriteLine(p2);
        }
    }
}
