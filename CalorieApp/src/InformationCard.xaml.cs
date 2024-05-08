namespace CalorieApp;

public partial class InformationCard : ContentView {
    public InformationCard() {
        InitializeComponent();
        InitializeInformationCard();
    }

    private void InitializeInformationCard() {
        CardTitleLabel.Text = "Macros";
        CardSubTitleLabel.Text = "Total Calories: 0";
        TopLeftLabel.LeftLabelText = "Fat:";
        BottomLeftLabel.LeftLabelText = "Protein:";
        TopRightLabel.LeftLabelText = "Carbs:";
        BottomRightLabel.LeftLabelText = "Alcohol:";
    }
}