namespace CalorieApp;

public partial class InformationLabel : ContentView {
    public readonly static BindableProperty LeftLabelProperty =
        BindableProperty.Create(nameof(LeftLabelText), typeof(string), typeof(InformationLabel), "Some Value:");

    public readonly static BindableProperty RightLabelProperty =
        BindableProperty.Create(nameof(RightLabelText), typeof(string), typeof(InformationLabel), "123");

    public readonly static BindableProperty TextAlignProperty = BindableProperty.Create(
        nameof(TextAlign),
        typeof(TextAlignment),
        typeof(InformationLabel),
        TextAlignment.Start);

    public InformationLabel() {
        InitializeComponent();
    }

    public string LeftLabelText {
        get => (string)GetValue(LeftLabelProperty);
        set => SetValue(LeftLabelProperty, value);
    }

    public string RightLabelText {
        get => (string)GetValue(RightLabelProperty);
        set => SetValue(RightLabelProperty, value);
    }

    public TextAlignment TextAlign {
        get => (TextAlignment)GetValue(TextAlignProperty);
        set => SetValue(TextAlignProperty, value);
    }

    protected override void OnParentSet() {
        base.OnParentSet();
        BindingContext = this;
    }
}