using System;

namespace pclSGlocalizacion
{
	public class ColorBean
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }

		public static ColorBean[] Colors {
			get {
				return new ColorBean[] {
					new ColorBean(){Id = 1, Name = SGLConstants.COLOR_GREEN_ES, Value = SGLConstants.COLOR_GREEN},
					new ColorBean(){Id = 2, Name = SGLConstants.COLOR_BLUE_ES, Value = SGLConstants.COLOR_BLUE},
					new ColorBean(){Id = 3, Name = SGLConstants.COLOR_ORANGE_ES, Value = SGLConstants.COLOR_ORANGE}
				};
			}
		}

		public ColorBean ()
		{
		}

		public override string ToString ()
		{
			return Name;
		}
		
	}
}

