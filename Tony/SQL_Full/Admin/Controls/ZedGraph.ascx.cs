using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using ZedGraph;
using ZedGraph.Web;
using System.Collections.Generic;

public enum AnalyticsType
{
    Line,   //折线图
    Bar,    //柱状图
    Pie     //饼图
}

public partial class Admin_Controls_ZedGraph : System.Web.UI.UserControl
{
    #region Private Attribute
    /**/
    /// <summary>
    /// 默认颜色种类
    /// </summary>
    private List<Color> defaultColors = new List<Color>();
    /**/
    /// <summary>
    /// 统计的个数
    /// </summary>
    private int Count;
    #endregion

    #region Public Property
    /**/
    /// <summary>
    /// 图片保存目录
    /// </summary>
    public string FilePath;
    /**/
    /// <summary>
    /// 统计图的名称
    /// </summary>
    public string Title;
    /**/
    /// <summary>
    /// 横轴的名称（饼图不需要）
    /// </summary>
    public string XAxisTitle;
    /**/
    /// <summary>
    /// 纵轴的名称（饼图不需要）
    /// </summary>
    public string YAxisTitle;
    /**/
    /// <summary>
    /// 显示的曲线类型：Line,Bar,Pie
    /// </summary>
    public AnalyticsType Type;
    /**/
    /// <summary>
    /// 折线图和柱状图的数据源
    /// </summary>
    public List<PointPairList> DataSource = new List<PointPairList>();
    /**/
    /// <summary>
    /// 饼图的数据源
    /// </summary>
    public List<double> ScaleData = new List<double>();
    /**/
    /// <summary>
    /// 各段数据的颜色
    /// </summary>
    public List<Color> Colors = new List<Color>();
    /**/
    /// <summary>
    /// 各段数据的名称
    /// </summary>
    public List<string> NameList = new List<string>();
    /**/
    /// <summary>
    /// 各折线的名称
    /// </summary>
    public List<string> CurveNameList = new List<string>();
    /**/
    /// <summary>
    /// 用于柱状图，每个圆柱体表示的含义
    /// </summary>
    public List<string> LabelList = new List<string>();
    /**/
    /// <summary>
    /// 用于柱状图的曲线
    /// </summary>
    public double[] CurveForBar;
    public bool IsCurveBar = false;
    /**/
    /// <summary>
    /// 控件宽度
    /// </summary>
    public int ZGWidth;
    /**/
    /// <summary>
    /// 控件高度
    /// </summary>
    public int ZGHeight;
    /**/
    /// <summary>
    /// 是否动态改变颜色
    /// </summary>
    public bool IsChangeColor = false;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        zedGraphControl.Width = ZGWidth;
        zedGraphControl.Height = ZGHeight;
        zedGraphControl.RenderGraph += new ZedGraph.Web.ZedGraphWebControlEventHandler(zedGraphControl_RenderGraph);

        //保存位置(ZedGraph/Images目录可以自定义)
        FilePath = "~/Admin/Controls/ZedGraph/";
        zedGraphControl.RenderedImagePath = FilePath;
    }

    private void InitDefaultColors()
    {
        //以下为颜色样例
        //defaultColors.Add(Color.Red);
        //defaultColors.Add(Color.Green);
        //defaultColors.Add(Color.Blue);
        //defaultColors.Add(Color.Yellow);
        //defaultColors.Add(Color.YellowGreen);
        //defaultColors.Add(Color.Brown);
        //defaultColors.Add(Color.Aqua);
        //defaultColors.Add(Color.Cyan);
        //defaultColors.Add(Color.DarkSeaGreen);
        //defaultColors.Add(Color.Indigo);

        if (IsChangeColor)
        {
            defaultColors.Add(Color.FromArgb(255, 158, 158));    //红色
            defaultColors.Add(Color.FromArgb(167, 233, 145));    //绿色
            defaultColors.Add(Color.FromArgb(145, 233, 255));    //蓝色
            defaultColors.Add(Color.FromArgb(255, 255, 145));    //黄色
            defaultColors.Add(Color.FromArgb(211, 233, 145));    //黄绿
            defaultColors.Add(Color.FromArgb(255, 145, 255));    //紫色
            defaultColors.Add(Color.FromArgb(0, 153, 255));
            defaultColors.Add(Color.FromArgb(255, 204, 0));
            defaultColors.Add(Color.FromArgb(76, 183, 255));//
            defaultColors.Add(Color.FromArgb(255, 214, 51));
            defaultColors.Add(Color.FromArgb(127, 204, 255));//
            defaultColors.Add(Color.FromArgb(255, 224, 102));
            defaultColors.Add(Color.FromArgb(166, 219, 255));//
            defaultColors.Add(Color.FromArgb(255, 235, 153));
            defaultColors.Add(Color.FromArgb(204, 235, 255));//
            defaultColors.Add(Color.FromArgb(255, 245, 204));
        }
        else
        {
            defaultColors.Add(Color.FromArgb(0, 153, 255));//
            defaultColors.Add(Color.FromArgb(255, 204, 0));
            defaultColors.Add(Color.FromArgb(76, 183, 255));//
            defaultColors.Add(Color.FromArgb(255, 214, 51));
            defaultColors.Add(Color.FromArgb(127, 204, 255));//
            defaultColors.Add(Color.FromArgb(255, 224, 102));
            defaultColors.Add(Color.FromArgb(166, 219, 255));//
            defaultColors.Add(Color.FromArgb(255, 235, 153));
            defaultColors.Add(Color.FromArgb(204, 235, 255));//
            defaultColors.Add(Color.FromArgb(255, 245, 204));
        }
    }
    /**/
    /// <summary>
    /// 如果属性为空则初始化属性数据
    /// </summary>
    private void InitProperty()
    {
        InitDefaultColors();
        if (string.IsNullOrEmpty(Title))
        {
            Title = string.Empty;
        }
        if (string.IsNullOrEmpty(XAxisTitle))
        {
            XAxisTitle = "横轴";
        }
        if (string.IsNullOrEmpty(YAxisTitle))
        {
            YAxisTitle = "纵轴";
        }
        if (Type == AnalyticsType.Pie)
        {
            Count = ScaleData.Count;
        }
        else
        {
            Count = DataSource.Count;
        }
        if (Colors.Count == 0 || Colors.Count != Count)
        {
            if (IsChangeColor)
            {
                for (int i = 0; i < 16; i++)
                {
                    Colors.Add(defaultColors[i]);
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    Colors.Add(defaultColors[i]);
                }
            }

        }
        if (NameList.Count == 0)
        {
            if (Type == AnalyticsType.Bar || Type == AnalyticsType.Line)
            {
                for (int i = 0; i < DataSource[0].Count; i++)
                {
                    NameList.Add((i + 1).ToString());
                }
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    NameList.Add((i + 1).ToString());
                }
            }
        }
        if (LabelList.Count == 0)
        {
            if (Count > 5)
            {
                int k = 1;
                for (int i = 0; i < Count; i++)
                {
                    LabelList.Add("名称 " + k.ToString());

                    if (i % 2 != 0)
                    {
                        k++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    LabelList.Add("名称 " + (i + 1).ToString());
                }
            }
        }
    }
    /**/
    /// <summary>
    /// 画图
    /// </summary>
    /// <param name="webObject"></param>
    /// <param name="g"></param>
    /// <param name="pane"></param>
    private void zedGraphControl_RenderGraph(ZedGraph.Web.ZedGraphWeb webObject, System.Drawing.Graphics g, ZedGraph.MasterPane pane)
    {
        InitProperty();

        GraphPane myPane = pane[0];

        if (Title != string.Empty)
        {
            myPane.Title.Text = Title;
        }
        myPane.XAxis.Title.Text = XAxisTitle;
        myPane.YAxis.Title.Text = YAxisTitle;
        //myPane.Border.Style = System.Drawing.Drawing2D.DashStyle.Dot;
        myPane.Border.Color = Color.White;

        switch (Type)
        {
            case AnalyticsType.Line:
                DrawLine(myPane);
                break;
            case AnalyticsType.Bar:
                DrawBar(myPane);
                break;
            case AnalyticsType.Pie:
                DrawPie(myPane);
                break;
            default:
                break;
        }
        pane.AxisChange(g);
    }

    #region Draw
    /// <summary>
    /// 为柱状图添加标签
    /// </summary>
    /// <param name="graphPane"></param>
    /// <param name="valueFormat"></param>
    /// <param name="valueDouble"></param>
    private void CreateBarLabels(GraphPane graphPane, string valueFormat, List<double> valueDouble)
    {
        for (int j = 0; j < valueDouble.Count; j++)
        {
            PointPair pt = new PointPair(j + 1, valueDouble[j]);
            TextObj text = new TextObj(pt.Y.ToString(valueFormat), pt.X, pt.Y > (double)10 ? pt.Y - 10 : pt.Y, CoordType.AxisXYScale, AlignH.Left, AlignV.Center);
            //text.ZOrder = ZOrder.A_InFront;
            //text.FontSpec.Border.IsVisible = false;
            //text.FontSpec.Fill.IsVisible = false;
            //text.FontSpec.Angle = 1; //数值字体倾斜度
            //text.FontSpec.Size = 12;
            //text.FontSpec.FontColor = Color.Black;
            ////text.FontSpec.IsBold = true;
            text.Location.CoordinateFrame = CoordType.AxisXY2Scale;
            text.Location.AlignH = AlignH.Center;
            text.Location.AlignV = AlignV.Center;
            graphPane.GraphObjList.Add(text);
        }
    }
    /**/
    /// <summary>
    /// 画折线图
    /// </summary>
    /// <param name="graphPane"></param>
    private void DrawLine(GraphPane graphPane)
    {
        for (int i = 0; i < Count; i++)
        {
            LineItem myCurve = graphPane.AddCurve(CurveNameList[i], DataSource[i], Colors[i], SymbolType.Circle);
            myCurve.Line.Fill = new Fill(Colors[i], Color.Transparent, -45F);  //显示区域颜色,可去掉
        }

        graphPane.XAxis.MajorTic.IsBetweenLabels = true;
        string[] labels = NameList.ToArray();
        graphPane.XAxis.Scale.TextLabels = labels;
        graphPane.XAxis.Type = AxisType.Text;
        graphPane.Fill = new Fill(Color.White, Color.White, 45.0f);
    }
    /**/
    /// <summary>
    /// 画柱状图
    /// </summary>
    /// <param name="graphPane"></param>
    private void DrawBar(GraphPane graphPane)
    {
        //折綫圖
        if (IsCurveBar)
        {
            LineItem myCurve = graphPane.AddCurve("公司名称", null, CurveForBar, Color.Black, SymbolType.Circle);
            //myCurve.Line.Fill = new Fill(Color.White, Color.Transparent, -45F);
            List<double> curveList = new List<double>();
            for (int i = 0; i < CurveForBar.Length; i++)
            {
                curveList.Add(CurveForBar[i]);
            }
            CreateBarLabels(graphPane, "f1", curveList);
        }

        //柱狀圖
        for (int i = 0; i < Count; i++)
        {
            //graphPane.AddBar(LabelList[i], DataSource[i], Colors[i]).Bar.Fill = new Fill(Colors[i], Color.White, Colors[i]);

            BarItem myBar = graphPane.AddBar(LabelList[i], DataSource[i], Colors[i]);
            myBar.Bar.Border = new Border(false, Color.Black, 0);
            myBar.Bar.Fill = new Fill(Colors[i]);

        }

        //graphPane.Legend.IsHStack = false;  //当有多个显示项的时候设置 Y 轴数据是叠加的还是分开的 (Title)
        //graphPane.BarSettings.Type = BarType.SortedOverlay; //当有多个显示项的时候设置 Y 轴数据是叠加的还是分开的


        graphPane.XAxis.MajorTic.IsBetweenLabels = true;
        string[] labels = NameList.ToArray();
        graphPane.XAxis.Scale.TextLabels = labels;
        graphPane.XAxis.Type = AxisType.Text;
        graphPane.Fill = new Fill(Color.White, Color.FromArgb(235, 235, 238), 45.0f);
        //graphPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
    }
    /**/
    /// <summary>
    /// 画饼图
    /// </summary>
    /// <param name="graphPane"></param>
    private void DrawPie(GraphPane graphPane)
    {
        graphPane.Fill = new Fill(Color.White, Color.White, 45.0f);
        graphPane.Legend.Position = LegendPos.Right;//LegendPos.Float;
        graphPane.Legend.Location = new Location(0.95f, 0.15f, CoordType.PaneFraction, AlignH.Right, AlignV.Top);
        graphPane.Legend.Border.Color = Color.White;
        graphPane.Legend.FontSpec.Size = 20f;
        graphPane.Legend.IsHStack = false;
        graphPane.Title.FontSpec.Size = 30f;

        for (int i = 0; i < Count; i++)
        {
            PieItem myPie = graphPane.AddPieSlice(ScaleData[i], Colors[i], Colors[i], 45f, 0, NameList[i]);
            myPie.LabelDetail.FontSpec.Size = 22f;
            myPie.LabelType = PieLabelType.Value;  //饼图上的文字注释
        }
    }
    /**/
    /// <summary>
    /// 如果系统出错，显示错误信息
    /// </summary>
    /// <param name="graphPane"></param>
    /// <param name="message"></param>
    private void DrawMessage(GraphPane graphPane, string message)
    {
        TextObj text = new TextObj(message, 200, 200);
        text.Text = message;
        graphPane.GraphObjList.Add(text);

    }
    #endregion
}