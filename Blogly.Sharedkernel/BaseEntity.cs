namespace Blogly.Sharedkernel;

public class BaseEntity<T>
{
    public T? Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    protected BaseEntity(T id)
    {
        id = id;
    }
}