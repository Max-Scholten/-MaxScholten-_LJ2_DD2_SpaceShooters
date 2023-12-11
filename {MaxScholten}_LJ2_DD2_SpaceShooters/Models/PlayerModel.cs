// PlayerModel.cs

using System.ComponentModel;
using System.Runtime.CompilerServices;

public class PlayerModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    private int score;
    private int healthPoints;
    private TimeSpan elapsedTime;

    public int Score
    {
        get { return score; }
        set
        {
            if (value != score)
            {
                score = value;
                OnPropertyChanged(nameof(Score));
            }
        }
    }

    public int HealthPoints
    {
        get { return healthPoints; }
        set
        {
            if (value != healthPoints)
            {
                healthPoints = value;
                OnPropertyChanged(nameof(HealthPoints));
            }
        }
    }

    public TimeSpan ElapsedTime
    {
        get { return elapsedTime; }
        set
        {
            if (value != elapsedTime)
            {
                elapsedTime = value;
                OnPropertyChanged(nameof(ElapsedTime));
            }
        }
    }

    
}
