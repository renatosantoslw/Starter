using DevExpress.Utils;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraPrinting.Native.DrillDown;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Native;
using DevExpress.XtraReports.Native.Data;
using DevExpress.XtraReports.Native.Presenters;
using DevExpress.XtraReports.Native.Printing;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.Serialization;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLER.FuncoesRelatorios;
using PDV.DAO.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace PDV.REPORTS.Reports.Modelo_1
{
    public partial class Modelo1 : DevExpress.XtraReports.UI.XtraReport
    {
        public Modelo1 (decimal IdVenda)
        {
            InitializeComponent();
            var dt = FuncoesPedidoVendaTermica.GetDAV(IdVenda);
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["observacao"] = dt.Rows[i]["observacao"].ToString() + dt.Rows[i]["pagamentosdescricao"].ToString();

            dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;
            
        }

        public override ISite Site { get => base.Site; set => base.Site = value; }

        public override FormattingRuleCollection FormattingRules => base.FormattingRules;

        public override XRControl Parent { get => base.Parent; set => base.Parent = value; }
        public override string NullValueText { get => base.NullValueText; set => base.NullValueText = value; }
        public override TextAlignment TextAlignment { get => base.TextAlignment; set => base.TextAlignment = value; }
        public override StringTrimming TextTrimming { get => base.TextTrimming; set => base.TextTrimming = value; }

        public override ExpressionBindingCollection ExpressionBindings => base.ExpressionBindings;

        public override object Value { get => base.Value; set => base.Value = value; }
        public override string TextFormatString { get => base.TextFormatString; set => base.TextFormatString = value; }
        public override float Dpi { get => base.Dpi; set => base.Dpi = value; }

        public override StyleUsing ParentStyleUsing => base.ParentStyleUsing;

        public override Font Font { get => base.Font; set => base.Font = value; }
        public override Color ForeColor { get => base.ForeColor; set => base.ForeColor = value; }
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }
        public override PaddingInfo Padding { get => base.Padding; set => base.Padding = value; }
        public override Color BorderColor { get => base.BorderColor; set => base.BorderColor = value; }
        public override BorderSide Borders { get => base.Borders; set => base.Borders = value; }
        public override float BorderWidth { get => base.BorderWidth; set => base.BorderWidth = value; }
        public override BorderDashStyle BorderDashStyle { get => base.BorderDashStyle; set => base.BorderDashStyle = value; }
        public override object Tag { get => base.Tag; set => base.Tag = value; }
        public override DrillDownKey DrillDownKey { get => base.DrillDownKey; set => base.DrillDownKey = value; }
        public override bool Visible { get => base.Visible; set => base.Visible = value; }

        public override XtraReport RootReport => base.RootReport;

        public override XtraReportBase Report => base.Report;

        public override ValueSuppressType ProcessNullValues { get => base.ProcessNullValues; set => base.ProcessNullValues = value; }
        public override ValueSuppressType ProcessDuplicates { get => base.ProcessDuplicates; set => base.ProcessDuplicates = value; }
        public override ProcessDuplicatesMode ProcessDuplicatesMode { get => base.ProcessDuplicatesMode; set => base.ProcessDuplicatesMode = value; }
        public override ProcessDuplicatesTarget ProcessDuplicatesTarget { get => base.ProcessDuplicatesTarget; set => base.ProcessDuplicatesTarget = value; }

        public override Band Band => base.Band;

        public override PaddingInfo SnapLineMargin { get => base.SnapLineMargin; set => base.SnapLineMargin = value; }

        public override bool CanHaveChildren => base.CanHaveChildren;

        public override bool CanPublish { get => base.CanPublish; set => base.CanPublish = value; }
        public override string NavigateUrl { get => base.NavigateUrl; set => base.NavigateUrl = value; }
        public override string Target { get => base.Target; set => base.Target = value; }
        public override XRControl BookmarkParent { get => base.BookmarkParent; set => base.BookmarkParent = value; }
        public override VerticalAnchorStyles AnchorVertical { get => base.AnchorVertical; set => base.AnchorVertical = value; }
        public override HorizontalAnchorStyles AnchorHorizontal { get => base.AnchorHorizontal; set => base.AnchorHorizontal = value; }
        public override float WidthF { get => base.WidthF; set => base.WidthF = value; }

        public override XRBindingCollection DataBindings => base.DataBindings;

        public override RectangleF BoundsF { get => base.BoundsF; set => base.BoundsF = value; }
        public override string Text { get => base.Text; set => base.Text = value; }
        public override string XlsxFormatString { get => base.XlsxFormatString; set => base.XlsxFormatString = value; }
        public override SizeF SizeF { get => base.SizeF; set => base.SizeF = value; }
        public override PointF LocationF { get => base.LocationF; set => base.LocationF = value; }
        public override PointFloat LocationFloat { get => base.LocationFloat; set => base.LocationFloat = value; }
        public override float LeftF { get => base.LeftF; set => base.LeftF = value; }
        public override float TopF { get => base.TopF; set => base.TopF = value; }

        public override float RightF => base.RightF;

        public override float BottomF => base.BottomF;

        public override bool CanGrow { get => base.CanGrow; set => base.CanGrow = value; }
        public override bool CanShrink { get => base.CanShrink; set => base.CanShrink = value; }
        public override bool WordWrap { get => base.WordWrap; set => base.WordWrap = value; }

        public override SubBandCollection SubBands => base.SubBands;

        public override PaddingInfo SnapLinePadding { get => base.SnapLinePadding; set => base.SnapLinePadding = value; }
        public override float HeightF { get => base.HeightF; set => base.HeightF = value; }

        public override XRControlStyles Styles => base.Styles;

        public override StylePriority StylePriority => base.StylePriority;

        public override string StyleName { get => base.StyleName; set => base.StyleName = value; }
        public override string EvenStyleName { get => base.EvenStyleName; set => base.EvenStyleName = value; }
        public override string OddStyleName { get => base.OddStyleName; set => base.OddStyleName = value; }
        public override string FilterString { get => base.FilterString; set => base.FilterString = value; }
        public override string XmlDataPath { get => base.XmlDataPath; set => base.XmlDataPath = value; }
        public override bool KeepTogether { get => base.KeepTogether; set => base.KeepTogether = value; }
        public override string Bookmark { get => base.Bookmark; set => base.Bookmark = value; }
        public override bool Expanded { get => base.Expanded; set => base.Expanded = value; }
        public override bool LockedInUserDesigner { get => base.LockedInUserDesigner; set => base.LockedInUserDesigner = value; }
        public override PageBreak PageBreak { get => base.PageBreak; set => base.PageBreak = value; }
        public override DevExpress.XtraReports.UI.RightToLeft RightToLeft { get => base.RightToLeft; set => base.RightToLeft = value; }

        public override string ControlType => base.ControlType;

        protected override bool CanRaiseEvents => base.CanRaiseEvents;

        protected override int DefaultWidth => base.DefaultWidth;

        protected override int DefaultHeight => base.DefaultHeight;

       // protected override bool CanChangeZOrder => base.CanChangeZOrder;


  

       // protected override bool CanDrawBackground => base.CanDrawBackground;

        protected override bool HasUndefinedBounds => base.HasUndefinedBounds;

        protected override bool NeedCalcContainerHeight => base.NeedCalcContainerHeight;

        protected override VerticalAnchorStyles DefaultAnchorVertical => base.DefaultAnchorVertical;

        protected override HorizontalAnchorStyles DefaultAnchorHorizontal => base.DefaultAnchorHorizontal;

        protected override bool ReportIsLoading => base.ReportIsLoading;

        protected override bool HasPageSummary => base.HasPageSummary;

        protected override bool HasRunningSummary => base.HasRunningSummary;

        protected override IList SerializableObjects => base.SerializableObjects;

      //  protected override bool IsImageEditable => base.IsImageEditable;

      //  protected override bool? HasImage => base.HasImage;

       // protected override string ControlsUnityName => base.ControlsUnityName;

       // protected override bool IsCrossbandControl => base.IsCrossbandControl;

       // protected override BrickOwnerType BrickOwnerType => base.BrickOwnerType;

        protected override RectangleF ClientRectangleF => base.ClientRectangleF;

        protected override BandKind BandKind => base.BandKind;

        protected override bool IsNavigateTarget => base.IsNavigateTarget;

        protected override string SortFieldsPropertyName => base.SortFieldsPropertyName;

        protected override int LevelInternal { get => base.LevelInternal; set => base.LevelInternal = value; }

        protected override bool CanHaveExportWarning => base.CanHaveExportWarning;

        protected override bool SupportSnapLines => base.SupportSnapLines;

        protected override float BoundsWidthF => base.BoundsWidthF;

        protected override DocumentBandKind DocumentBandKind => base.DocumentBandKind;


        //protected override ControlLayoutRules LayoutRules => base.LayoutRules;

        protected override bool SuppressListFillingInDataContext => base.SuppressListFillingInDataContext;

        protected override int DisplayableRowCount => base.DisplayableRowCount;

        protected override GroupFieldCollection SortFieldsInternal => base.SortFieldsInternal;

        protected override UrlResolver UrlResolver => base.UrlResolver;

        public override event PrintEventHandler BeforePrint;
        public override event EventHandler AfterPrint;
        public override event PrintOnPageEventHandler PrintOnPage;
        public override event PreviewMouseEventHandler PreviewMouseMove;
        public override event PreviewMouseEventHandler PreviewMouseDown;
        public override event PreviewMouseEventHandler PreviewMouseUp;
        public override event PreviewMouseEventHandler PreviewClick;
        public override event PreviewMouseEventHandler PreviewDoubleClick;
        public override event DrawEventHandler Draw;
        public override event EventHandler TextChanged;
        public override event DevExpress.XtraReports.UI.ChangeEventHandler SizeChanged;
        public override event DevExpress.XtraReports.UI.ChangeEventHandler LocationChanged;
        public override event DevExpress.XtraReports.UI.ChangeEventHandler ParentChanged;
        public override event BindingEventHandler EvaluateBinding;
        public override event BandEventHandler FillEmptySpace;
        public override event HtmlEventHandler HtmlItemCreated;

        public override void CreateDocument(bool buildForInstantPreview)
        {
            base.CreateDocument(buildForInstantPreview);
        }

        public override ObjRef CreateObjRef(Type requestedType)
        {
            return base.CreateObjRef(requestedType);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override BorderDashStyle GetEffectiveBorderDashStyle()
        {
            return base.GetEffectiveBorderDashStyle();
        }

        public override Font GetEffectiveFont()
        {
            return base.GetEffectiveFont();
        }

        public override Color GetEffectiveForeColor()
        {
            return base.GetEffectiveForeColor();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override object InitializeLifetimeService()
        {
            return base.InitializeLifetimeService();
        }

        public override void PerformLayout()
        {
            base.PerformLayout();
        }

        public override void RemoveInvalidBindings(Predicate<XRBinding> predicate)
        {
            base.RemoveInvalidBindings(predicate);
        }

        public override void ResetBackColor()
        {
            base.ResetBackColor();
        }

        public override void ResetBorderDashStyle()
        {
            base.ResetBorderDashStyle();
        }

        public override void ResetBorders()
        {
            base.ResetBorders();
        }

        public override void ResetBorderWidth()
        {
            base.ResetBorderWidth();
        }

        public override void ResetPadding()
        {
            base.ResetPadding();
        }

        public override Image ToImage()
        {
            return base.ToImage();
        }

        public override Image ToImage(TextRenderingHint textRenderingHint)
        {
            return base.ToImage(textRenderingHint);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void AddToSummaryUpdater(VisualBrick brick, VisualBrick prototypeBrick)
        {
            base.AddToSummaryUpdater(brick, prototypeBrick);
        }

        protected override void AdjustDataSource()
        {
            base.AdjustDataSource();
        }

        protected override void AfterReportPrint()
        {
            base.AfterReportPrint();
        }

        protected override void BeforeReportPrint()
        {
            base.BeforeReportPrint();
        }

        /*
        protected override float CalculateBrickHeight(VisualBrick brick)
        {
            return base.CalculateBrickHeight(brick);
        }
        */

        protected override bool CanAddControl(Type componentType, XRControl control)
        {
            return base.CanAddControl(componentType, control);
        }

        protected override void CollectAssociatedComponents(DesignItemList components)
        {
            base.CollectAssociatedComponents(components);
        }

        protected override void CopyDataProperties(XRControl source)
        {
            base.CopyDataProperties(source);
        }

        protected override void CopyFrom(XtraReport source, bool forceDataSource)
        {
            base.CopyFrom(source, forceDataSource);
        }

        protected override void CopyProperties(XRControl control)
        {
            base.CopyProperties(control);
        }

        /*
        protected override void CorrectEffectiveXRStyle(XRControlStyle style)
        {
            base.CorrectEffectiveXRStyle(style);
        }
        */

        protected override DocumentBand CreateBandContainer(DocumentBandKind kind, int rowIndex)
        {
            return base.CreateBandContainer(kind, rowIndex);
        }

        protected override BandPresenter CreateBandPresenter()
        {
            return base.CreateBandPresenter();
        }

        protected override VisualBrick CreateBrick(VisualBrick[] childrenBricks)
        {
            return base.CreateBrick(childrenBricks);
        }

        protected override XRControlCollection CreateChildControls()
        {
            return base.CreateChildControls();
        }

        protected override XtraReport CreateClone()
        {
            return base.CreateClone();
        }

        protected override object CreateCollectionItem(string propertyName, XtraItemEventArgs e)
        {
            return base.CreateCollectionItem(propertyName, e);
        }

        protected override DocumentBand CreateDocumentBand(PrintingSystemBase ps, int rowIndex, PageBuildInfo pageBuildInfo, bool raiseEnvent = true)
        {
            return base.CreateDocumentBand(ps, rowIndex, pageBuildInfo, raiseEnvent);
        }

        protected override DocumentBuilderBase CreateDocumentBuilder(PrintingDocument doc)
        {
            return base.CreateDocumentBuilder(doc);
        }

        protected override DocumentBand CreateEmptyDocumentBand()
        {
            return base.CreateEmptyDocumentBand();
        }

        protected override ControlPresenter CreatePresenter()
        {
            return base.CreatePresenter();
        }

        protected override PrintingSystemBase CreatePrintingSystemCore()
        {
            return base.CreatePrintingSystemCore();
        }

        /*
        protected override PSDocument CreatePSDocument(PrintingSystemBase ps, MethodInvoker afterBuildPages)
        {
            return base.CreatePSDocument(ps, afterBuildPages);
        }
        */
        protected override XRControlScripts CreateScripts()
        {
            return base.CreateScripts();
        }

        protected override XRControlStyles CreateStyles()
        {
            return base.CreateStyles();
        }

        protected override void DeserializeProperties(XRSerializer serializer)
        {
            base.DeserializeProperties(serializer);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void DisposeDataContext()
        {
            base.DisposeDataContext();
        }

        protected override bool EndOfData()
        {
            return base.EndOfData();
        }

        protected override void FillAttachedRules(List<FormattingRule> attachedRules)
        {
            base.FillAttachedRules(attachedRules);
        }

        protected override void FillAttachedStyles(List<XRControlStyle> attachedStyles)
        {
            base.FillAttachedStyles(attachedStyles);
        }

        protected override void FinishPageSummary()
        {
            base.FinishPageSummary();
        }

        protected override void GenerateContent(DocumentBand docBand, int rowIndex, PrintEventArgs args)
        {
            base.GenerateContent(docBand, rowIndex, args);
        }

        protected override Band GetBand()
        {
            return base.GetBand();
        }

        protected override RectangleF GetBrickBounds()
        {
            return base.GetBrickBounds();
        }

        protected override RectangleF GetClientRectangle()
        {
            return base.GetClientRectangle();
        }

        protected override BorderSide GetCorrectBorders()
        {
            return base.GetCorrectBorders();
        }

        protected override VisualBrick GetDesignerBrick(PrintingSystemBase ps, XRWriteInfo writeInfo)
        {
            return base.GetDesignerBrick(ps, writeInfo);
        }

        protected override float GetDocumentBandSelfHeight(float docBandSelfHeight)
        {
            return base.GetDocumentBandSelfHeight(docBandSelfHeight);
        }

        protected override float GetDocumentBandTotalHeight(float docBandTotalHeight)
        {
            return base.GetDocumentBandTotalHeight(docBandTotalHeight);
        }

        protected override PaddingInfo GetLegacyDefaultPadding(float dpi)
        {
            return base.GetLegacyDefaultPadding(dpi);
        }

        protected override object GetMergeValue()
        {
            return base.GetMergeValue();
        }

        protected override int GetMinimumHeight()
        {
            return base.GetMinimumHeight();
        }

        protected override int GetMinimumWidth()
        {
            return base.GetMinimumWidth();
        }

        protected override VisualBrick GetPrintableBrick(XRWriteInfo writeInfo)
        {
            return base.GetPrintableBrick(writeInfo);
        }

        protected override PrintingSystemBase GetPrintingSystem()
        {
            return base.GetPrintingSystem();
        }

        protected override XtraReportBase GetReport()
        {
            return base.GetReport();
        }

        protected override XtraReport GetRootReport()
        {
            return base.GetRootReport();
        }

        protected override object GetService(Type service)
        {
            return base.GetService(service);
        }

        protected override void GetStateFromBrick(VisualBrick brick)
        {
            base.GetStateFromBrick(brick);
        }

        protected override object GetTextValue()
        {
            return base.GetTextValue();
        }

        protected override string GetTextValueFormatString()
        {
            return base.GetTextValueFormatString();
        }

        protected override object GetValueForMergeKey()
        {
            return base.GetValueForMergeKey();
        }

        protected override object GetValueForSuppress()
        {
            return base.GetValueForSuppress();
        }

        protected override int GetWeightingFactor()
        {
            return base.GetWeightingFactor();
        }

        /*
        protected override bool HasBindings()
        {
            return base.HasBindings();
        }
        */
        protected override bool HasExportWarning()
        {
            return base.HasExportWarning();
        }

        protected override bool HasMultiColumnPrintingWarning()
        {
            return base.HasMultiColumnPrintingWarning();
        }

        protected override bool HasPrintingWarning()
        {
            return base.HasPrintingWarning();
        }

        protected override bool IgnoreInnerControls()
        {
            return base.IgnoreInnerControls();
        }

        protected override bool IgnorePrintCancel(bool isSecondaryContent)
        {
            return base.IgnorePrintCancel(isSecondaryContent);
        }

        protected override void InitializeDocumentBand(DocumentBand docBand)
        {
            base.InitializeDocumentBand(docBand);
        }

        protected override void InitializeScripts()
        {
            base.InitializeScripts();
        }

        protected override void InsertPageBreaks(DocumentBand docBand)
        {
            base.InsertPageBreaks(docBand);
        }


        /*
        protected override bool IntersectsWithChildren(float epsilon)
        {
            return base.IntersectsWithChildren(epsilon);
        }

        protected override bool IntersectsWithParent(float epsilon)
        {
            return base.IntersectsWithParent(epsilon);
        }
        
        protected override bool IntersectsWithSiblings(float epsilon)
        {
            return base.IntersectsWithSiblings(epsilon);
        }
        */

        protected override bool IsEmptyValue(object value)
        {
            return base.IsEmptyValue(value);
        }

        protected override bool IsSafeToGetData()
        {
            return base.IsSafeToGetData();
        }

        protected override bool NeedSuppressDuplicatesByValue()
        {
            return base.NeedSuppressDuplicatesByValue();
        }

        protected override bool NeedSuppressNullValue()
        {
            return base.NeedSuppressNullValue();
        }

        protected override void OnAfterPrint(EventArgs e)
        {
            base.OnAfterPrint(e);
        }

        protected override void OnBandHeightChanged(BandEventArgs e)
        {
            base.OnBandHeightChanged(e);
        }

        protected override void OnBeforePrint(PrintEventArgs e)
        {
            base.OnBeforePrint(e);
        }

        protected override void OnBordersChanged()
        {
            base.OnBordersChanged();
        }

        protected override void OnBorderWidthChanged()
        {
            base.OnBorderWidthChanged();
        }

        protected override void OnBoundsChanged(RectangleF oldBounds, RectangleF newBounds)
        {
            base.OnBoundsChanged(oldBounds, newBounds);
        }

        protected override void OnControlCollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            base.OnControlCollectionChanged(sender, e);
        }

        protected override void OnDataSourceChanging()
        {
            base.OnDataSourceChanging();
        }

        protected override void OnDataSourceDemanded(EventArgs e)
        {
            base.OnDataSourceDemanded(e);
        }

        protected override void OnDataSourceRowChanged(DataSourceRowEventArgs e)
        {
            base.OnDataSourceRowChanged(e);
        }

        protected override void OnDeserialize(XRSerializerEventArgs e)
        {
            base.OnDeserialize(e);
        }

        protected override void OnDesignerLoaded(DesignerLoadedEventArgs e)
        {
            base.OnDesignerLoaded(e);
        }

        protected override void OnDisposing()
        {
            base.OnDisposing();
        }

        protected override void OnDraw(DrawEventArgs e)
        {
            base.OnDraw(e);
        }

        protected override void OnEndDeserializing(string restoredVersion)
        {
            base.OnEndDeserializing(restoredVersion);
        }

        protected override void OnEvaluateBinding(BindingEventArgs e)
        {
            base.OnEvaluateBinding(e);
        }

        protected override void OnFillEmptySpace(BandEventArgs e)
        {
            base.OnFillEmptySpace(e);
        }

        protected override void OnFontChanged(Font prevValue, Font value)
        {
            base.OnFontChanged(prevValue, value);
        }

        protected override void OnForeColorChanged()
        {
            base.OnForeColorChanged();
        }

        protected override void OnHtmlItemCreated(HtmlEventArgs e)
        {
            base.OnHtmlItemCreated(e);
        }

        protected override void OnLocationChanged(DevExpress.XtraReports.UI.ChangeEventArgs e)
        {
            base.OnLocationChanged(e);
        }

        protected override void OnParametersRequestBeforeShow(ParametersRequestEventArgs e)
        {
            base.OnParametersRequestBeforeShow(e);
        }

        protected override void OnParametersRequestSubmit(ParametersRequestEventArgs e)
        {
            base.OnParametersRequestSubmit(e);
        }

        protected override void OnParametersRequestValueChanged(ParametersRequestValueChangedEventArgs e)
        {
            base.OnParametersRequestValueChanged(e);
        }

        protected override void OnParentBoundsChanged(XRControl parent, RectangleF oldBounds, RectangleF newBounds)
        {
            base.OnParentBoundsChanged(parent, oldBounds, newBounds);
        }

        protected override void OnParentChanged(DevExpress.XtraReports.UI.ChangeEventArgs e)
        {
            base.OnParentChanged(e);
        }

        protected override void OnPreviewClick(PreviewMouseEventArgs e)
        {
            base.OnPreviewClick(e);
        }

        protected override void OnPreviewDoubleClick(PreviewMouseEventArgs e)
        {
            base.OnPreviewDoubleClick(e);
        }

        protected override void OnPreviewMouseDown(PreviewMouseEventArgs e)
        {
            base.OnPreviewMouseDown(e);
        }

        protected override void OnPreviewMouseMove(PreviewMouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
        }

        protected override void OnPreviewMouseUp(PreviewMouseEventArgs e)
        {
            base.OnPreviewMouseUp(e);
        }

        protected override void OnPrintOnPage(PrintOnPageEventArgs e)
        {
            base.OnPrintOnPage(e);
        }

        protected override void OnReportEndDeserializing()
        {
            base.OnReportEndDeserializing();
        }

        protected override void OnReportInitialize()
        {
            base.OnReportInitialize();
        }

        protected override void OnSaveComponents(SaveComponentsEventArgs e)
        {
            base.OnSaveComponents(e);
        }

        protected override void OnScriptException(ScriptExceptionEventArgs args)
        {
            base.OnScriptException(args);
        }

        protected override void OnSerialize(XRSerializerEventArgs e)
        {
            base.OnSerialize(e);
        }

        protected override void OnSizeChanged(DevExpress.XtraReports.UI.ChangeEventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void OnStartDeserializing(LayoutAllowEventArgs e)
        {
            base.OnStartDeserializing(e);
        }

        protected override void OnStartSerializing()
        {
            base.OnStartSerializing();
        }

        protected override void OnSubBandsChanged(object sender, CollectionChangeEventArgs e)
        {
            base.OnSubBandsChanged(sender, e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override void printingSystem_AfterBuildPages(object sender, EventArgs e)
        {
            base.printingSystem_AfterBuildPages(sender, e);
        }

        protected override void PutStateToBrick(VisualBrick brick, PrintingSystemBase ps)
        {
            base.PutStateToBrick(brick, ps);
        }

        /*
        protected override void RaiseParametersRequestBeforeShow(IList<ParameterInfo> parametersInfo)
        {
            base.RaiseParametersRequestBeforeShow(parametersInfo);
        }
        */

        protected override void RaiseParametersRequestSubmit(IList<ParameterInfo> parametersInfo, bool createDocument)
        {
            base.RaiseParametersRequestSubmit(parametersInfo, createDocument);
        }

        protected override bool RaisePrintOnPage(VisualBrick brick, Page page, int pageIndex, int pageCount)
        {
            return base.RaisePrintOnPage(brick, page, pageIndex, pageCount);
        }

        protected override void RaiseSummaryCalculated(VisualBrick brick, string text, string format, object value)
        {
            base.RaiseSummaryCalculated(brick, text, format, value);
        }

        protected override void ResetBookmark()
        {
            base.ResetBookmark();
        }

        protected override void RestoreInitialPropertyValues()
        {
            base.RestoreInitialPropertyValues();
        }

        protected override void SaveInitialPropertyValues()
        {
            base.SaveInitialPropertyValues();
        }

        protected override void SaveLayoutInternal(Stream stream)
        {
            base.SaveLayoutInternal(stream);
        }

        protected override void SerializeProperties(XRSerializer serializer)
        {
            base.SerializeProperties(serializer);
        }

        /*
        protected override void SetBounds(float x, float y, float width, float height, DevExpress.XtraReports.Native.BoundsSpecified specified)
        {
            base.SetBounds(x, y, width, height, specified);
        }
        */

        protected override void SetBrickText(VisualBrick brick, string text, object textValue)
        {
            base.SetBrickText(brick, text, textValue);
        }

        protected override void SetDataPosition(int[] indexPath)
        {
            base.SetDataPosition(indexPath);
        }

        protected override object SetDataSource(object dataSource)
        {
            return base.SetDataSource(dataSource);
        }

        protected override void SetIndexCollectionItem(string propertyName, XtraSetItemIndexEventArgs e)
        {
            base.SetIndexCollectionItem(propertyName, e);
        }

        protected override void SetParent(XRControl value)
        {
            base.SetParent(value);
        }

        protected override void SetPrintingSystemValue(PrintingSystemBase val)
        {
            base.SetPrintingSystemValue(val);
        }

        protected override void SetProgressRanges(float progressRange)
        {
            base.SetProgressRanges(progressRange);
        }

        protected override void SetShrinkGrow(VisualBrick brick)
        {
            base.SetShrinkGrow(brick);
        }

        protected override bool ShouldSerializeBackColor()
        {
            return base.ShouldSerializeBackColor();
        }

        protected override bool ShouldSerializeBookmark()
        {
            return base.ShouldSerializeBookmark();
        }

        protected override bool ShouldSerializeBorderColor()
        {
            return base.ShouldSerializeBorderColor();
        }

        protected override bool ShouldSerializeBorderDashStyle()
        {
            return base.ShouldSerializeBorderDashStyle();
        }

        protected override bool ShouldSerializeBorders()
        {
            return base.ShouldSerializeBorders();
        }

        protected override bool ShouldSerializeBorderWidth()
        {
            return base.ShouldSerializeBorderWidth();
        }

        protected override bool ShouldSerializeFont()
        {
            return base.ShouldSerializeFont();
        }

        protected override bool ShouldSerializeForeColor()
        {
            return base.ShouldSerializeForeColor();
        }

        protected override bool ShouldSerializePadding()
        {
            return base.ShouldSerializePadding();
        }

        protected override bool ShouldSerializeTextAlignment()
        {
            return base.ShouldSerializeTextAlignment();
        }

        /*
        protected override void SwapWith(XRControl item)
        {
            base.SwapWith(item);
        }
        */

        protected override void SyncDpi(float dpi)
        {
            base.SyncDpi(dpi);
        }

        protected override void UpdateBindingCore(XRDataContext dataContext, ImagesContainer images)
        {
            base.UpdateBindingCore(dataContext, images);
        }

        protected override void UpdateBrickBounds(VisualBrick brick)
        {
            base.UpdateBrickBounds(brick);
        }

        protected override void UpdateLayout()
        {
            base.UpdateLayout();
        }

        protected override void ValidateBrick(VisualBrick brick, RectangleF bounds, PointF offset)
        {
            base.ValidateBrick(brick, bounds, offset);
        }

        protected override void ValidateDataMember(string newMember, string oldMember)
        {
            base.ValidateDataMember(newMember, oldMember);
        }

        protected override void ValidateDataSource(object newSource, object oldSource, string dataMember)
        {
            base.ValidateDataSource(newSource, oldSource, dataMember);
        }

        protected override void ValidateTextFormatString(string textFormatString)
        {
            base.ValidateTextFormatString(textFormatString);
        }

        protected override void WriteContentTo(XRWriteInfo writeInfo, VisualBrick brick)
        {
            base.WriteContentTo(writeInfo, brick);
        }

        protected override void WriteContentToCore(XRWriteInfo writeInfo, VisualBrick brick)
        {
            base.WriteContentToCore(writeInfo, brick);
        }
    }
}
