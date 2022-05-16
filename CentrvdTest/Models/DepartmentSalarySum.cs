namespace CentrvdTest.Models
{
	public class DepartmentSalarySum
	{
		// Id департамента
		public int Id { get; set; }

		// сумма зарплат по каждому департаменту (вместе с руководителями)
		public string Sum1 { get; set; }

		// сумма зарплат по каждому департаменту (ьез руководителей)
		public string Sum2 { get; set; }
	}
}
