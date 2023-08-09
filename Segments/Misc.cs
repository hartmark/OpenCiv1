using Disassembler;

namespace OpenCiv1
{
	public class Misc
	{
		private OpenCiv1 oParent;
		private CPU oCPU;
		private ushort usSegment = 0;

		public Misc(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public ushort Segment
		{
			get { return this.usSegment; }
			set { this.usSegment = value; }
		}

		public void F0_0000_0042()
		{
			this.oCPU.Log.EnterBlock("'F0_0000_0042'(Cdecl, Far) at 0x0000:0x0042");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.High = 0x1;
			this.oCPU.INT(0x21);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_0000_0042'");
		}
	}
}
