namespace _278._First_Bad_Version;

public class VersionControl
{
    private int _badVersion;

    public bool IsBadVersion(int version)
    {
        return version >= _badVersion;
    }

    public void SetBadVersion(int version)
    {
        _badVersion = version;
    }
}
