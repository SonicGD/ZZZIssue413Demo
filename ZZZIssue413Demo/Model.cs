using System.ComponentModel.DataAnnotations;

namespace ZZZIssue413Demo
{
    public class Model
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public TestEnum Test { get; set; }
        
        [Required]
        public TestEnum Test2 { get; set; }
    }

    public enum TestEnum
    {
        Foo = 0,
        Bar = 1
    }
}