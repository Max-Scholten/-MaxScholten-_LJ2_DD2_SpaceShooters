using System.ComponentModel;

public class GameModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private PlayerModel? playerModel; // Declare as nullable
    private int healthPoints;
    private int score;
    private TimeSpan elapsedTime;

    public PlayerModel? PlayerModel // Nullable property
    {
        get { return playerModel; }
        set
        {
            if (value != playerModel)
            {
                playerModel = value;
                OnPropertyChanged(nameof(PlayerModel));
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
