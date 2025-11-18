using CounterArkadiusz4F.Models;

namespace CounterArkadiusz4F.Views;

public partial class AllCountersPage : ContentPage
{
	public AllCountersPage()
	{
		InitializeComponent();
		BindingContext = new AllCounters();
	}

	private void SubtractButtonClicked(object sender, EventArgs e)
	{
		var counter = (Counter)((BindableObject)sender).BindingContext;
		var counters = ((AllCounters)BindingContext).Counters;
		int index = counters.IndexOf(counter);

		int newValue = counter.Value - 1;

		var newCounter = new Counter()
		{
			Id = counter.Id,
			Name = counter.Name,
			Value = newValue
		};

		counters[index] = newCounter;
        OnAnyChange();
        
    }

	private void AddButtonClicked(object sender, EventArgs e)
	{
        var counter = (Counter)((BindableObject)sender).BindingContext;
        var counters = ((AllCounters)BindingContext).Counters;
        int index = counters.IndexOf(counter);

        int newValue = counter.Value + 1;

        var newCounter = new Counter()
        {
            Id = counter.Id,
            Name = counter.Name,
            Value = newValue
        };

        counters[index] = newCounter;
        OnAnyChange();
    }
	private void NewCounterButtonClicked(object sender, EventArgs e)
	{
		try
		{
            int counterValue = int.Parse(InitialValueEntry.Text);
            string counterName = CounterNameEntry.Text;
            var counters = ((AllCounters)BindingContext).Counters;
            int newId = counters.Count > 0 ? counters.Max(c => c.Id) + 1 : 1;
            var newCounter = new Counter()
            {
                Id = newId,
                Name = counterName,
                Value = counterValue
            };
            counters.Add(newCounter);
            InitialValueEntry.Text = "10";
            CounterNameEntry.Text = "Nazwa Licznika";
			OnAnyChange();
        }
        catch(FormatException exception)
		{
            CounterNameEntry.Text = "W wartoœci pocz¹tkowej mo¿na podawaæ tylko liczby! ";
        }
    }
	private void OnAnyChange()
	{
        var counters = ((AllCounters)BindingContext).Counters;
        var filepath = "../../../../../counters.csv";
		string finalText = "";
        for (int i = 0; i < counters.Count; i++)
		{
			
            string counterId = counters[i].Id.ToString();
            string counterName = counters[i].Name;
			string counterValue = counters[i].Value.ToString();
			string line = $"{counterId},{counterName},{counterValue}";
            finalText += line + "\n";
        }
        File.WriteAllText(filepath, finalText);
    }


}