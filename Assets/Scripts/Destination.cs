public class Destination {
    public SphereTexture NowTexture { get; }

    private string _front;

    public string Front {
        get => _front;
        set {
            _front = value;
            FrontTexture = new SphereTexture(value);
        }
    }

    public SphereTexture FrontTexture { get; private set; }

    private string _back;

    public string Back {
        get => _back;
        set {
            _back = value;
            BackTexture = new SphereTexture(value);
        }
    }

    public SphereTexture BackTexture { get; private set; }

    private string _right;

    public string Right {
        get => _right;
        set {
            _right = value;
            RightTexture = new SphereTexture(value);
        }
    }

    public SphereTexture RightTexture { get; private set; }

    private string _left;
    public string Left {
        get => _left;
        set {
            _left = value;
            LeftTexture = new SphereTexture(value);
        }
    }

    public SphereTexture LeftTexture { get; private set; }

    public Destination(string fileName) {
        NowTexture = new SphereTexture(fileName);
    }
}