namespace Shoe4U.Models.Reviews;

public class ReviewDetailsOutputModel
{
	public DateTime CreatedOn { get; set; } = DateTime.Now;

	public string Content { get; set; }

	public string UserName { get; set; }
}
