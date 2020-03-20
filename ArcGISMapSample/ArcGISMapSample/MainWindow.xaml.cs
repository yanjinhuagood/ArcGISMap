using ArcGISMapSample.MapService;
using Esri.ArcGISRuntime.Mapping;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ArcGISMapSample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Map myMap;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            Initialize();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<MapType> mapList = new List<MapType>()
            {
                new MapType(){ ID="baidu",Name="百度" },
                new MapType(){ ID="amap",Name="高德" },
                new MapType(){ ID="tencent",Name="腾讯" },
            };
            MapTypeComboBox.ItemsSource = mapList;
            MapTypeComboBox.SelectedIndex = 1;
        }

        private void Initialize()
        {
            myMap = new Map();
            MyMapView.Map = myMap;

        }

        private void MapTypeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            MapType map = box.SelectedItem as MapType;
            switch (map.ID)
            {
                case "baidu":
                    myMap.OperationalLayers.Clear();
                    BaiduMapLayer baiduMap = new BaiduMapLayer();
                    baiduMap.Id = "MapLayer";
                    myMap.OperationalLayers.Add(baiduMap);
                    break;
                case "tencent":
                    myMap.OperationalLayers.Clear();
                    TencentMapLayer tencentMap = new TencentMapLayer();
                    myMap.OperationalLayers.Add(tencentMap);
                    tencentMap.Id = "MapLayer";
                    break;
                case "amap":
                    myMap.OperationalLayers.Clear();
                    AMapLayer aMap = new AMapLayer();
                    myMap.OperationalLayers.Add(aMap);
                    aMap.Id = "MapLayer";
                    break;
                default:

                    break;
            }
        }
    }
    public class MapType
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}
