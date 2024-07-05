using System;
namespace GraphQL_Sample.Models.Entity
{
	public class SupportEntity
	{
		public int Id { get; set; }
		public int ScoinId { get; set; }
		public string? ScoinName { get; set; }
		public int InfluencerId { get; set;  }
		public DateTime SupportDate { get; set;  }
		public int Status { get; set; }
	}
}

