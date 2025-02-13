using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class StartGameMenu
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public StartGameMenu(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_0000()
		{
			this.oCPU.Log.EnterBlock("F5_0000_0000()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x12);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x0007, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x0024, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			// Instruction address 0x0000:0x002c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x7);

			// Instruction address 0x0000:0x0042, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Difficulty Level...\n Chieftain (easiest)\n Warlord\n Prince\n King\n Emperor (toughest)\n");

			// Instruction address 0x0000:0x0056, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 160, 35, 1);

			this.oParent.GameState.DifficultyLevel = (short)this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L009b;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fa2), 0x0);
			if (this.oCPU.Flags.E) goto L009b;

			// Instruction address 0x0000:0x006f, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();

			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x87);
			if (this.oCPU.Flags.GE) goto L009b;

			// Instruction address 0x0000:0x0090, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((short)this.oParent.Var_db3e - 12) / 35, 0, 4);

			this.oParent.GameState.DifficultyLevel = (short)this.oCPU.AX.Word;

		L009b:
			if (oParent.GameState.DifficultyLevel != -1) goto L00a8;
			this.oParent.GameState.DifficultyLevel = 0;

		L00a8:
			// Instruction address 0x0000:0x00a8, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x00c0, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 150, 200, 0);

			this.oCPU.TESTByte((byte)(this.oParent.GameState.DifficultyLevel & 0xff), 0x1);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x0000:0x00fb, size: 5
				this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
					0x50, (ushort)((0x23 * this.oParent.GameState.DifficultyLevel) + 6), 0x35, 0x2f,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
					0x14, 0x64);
			}
			else
			{
				// Instruction address 0x0000:0x00fb, size: 5
				this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
					0x15, (ushort)((0x23 * this.oParent.GameState.DifficultyLevel) + 6), 0x35, 0x2f,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
					0x14, 0x64);
			}

			// Instruction address 0x0000:0x0121, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0x96, 0, 0xa0, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x96, 0);

			// Instruction address 0x0000:0x0129, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x0136, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Level of Competition...\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x7);

		L0143:
			// Instruction address 0x0000:0x015b, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 10));

			// Instruction address 0x0000:0x016b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Civilizations\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x2);
			if (this.oCPU.Flags.G) goto L0143;

		L017c:
			// Instruction address 0x0000:0x0188, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 160, 35, 1);

			oParent.GameState.AIOpponentCount = (short)this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L017c;

			// Instruction address 0x0000:0x01a8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(6 - this.oParent.GameState.AIOpponentCount, 2, 6);

			oParent.GameState.AIOpponentCount = (short)this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xff;
			this.oCPU.CX.Low = 0x6;
			this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, (byte)(this.oParent.GameState.AIOpponentCount & 0xff));
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oParent.GameState.ActiveCivilizations = (short)this.oCPU.AX.Word;

			// Instruction address 0x0000:0x01c1, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.AIOpponentCount;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			goto L01e1;			

		L01d1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L01e1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x0);
			if (this.oCPU.Flags.L) goto L021d;

			this.oCPU.TESTByte((byte)(this.oParent.GameState.DifficultyLevel & 0xff), 0x1);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x0000:0x01d6, size: 5
				this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
					0x50, (ushort)((0x23 * this.oParent.GameState.DifficultyLevel) + 6), 0x35, 0x2f,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
					(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) << 1) + 0x14),
					(ushort)((0x3 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))) + 0x64));
			}
			else
			{
				// Instruction address 0x0000:0x01d6, size: 5
				this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
					0x15, (ushort)((0x23 * this.oParent.GameState.DifficultyLevel) + 6), 0x35, 0x2f,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
					(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) << 1) + 0x14),
					(ushort)((0x3 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))) + 0x64));

			}
			goto L01d1;

		L021d:
			this.oParent.GameState.Year = -4000;
			this.oParent.GameState.DebugFlags = 0xf;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L022e:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0xff;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].NameID = this.oCPU.AX.Low;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].StatusFlag = this.oCPU.AX.Low;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x80);
			if (this.oCPU.Flags.L) goto L022e;

			for (int i = 0; i < 256; i++)
			{
				this.oParent.GameState.CityPositions[i].X = -1;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L026b:
			this.oParent.GameState.TechnologyFirstDiscoveredBy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))] = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x48);
			if (this.oCPU.Flags.L) goto L026b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L0289:
			this.oParent.GameState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))] = -1;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x15);
			if (this.oCPU.Flags.LE) goto L0289;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L02a2:
			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].LeaderGraphics = -1;

			F5_0000_1d1a(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8);
			if (this.oCPU.Flags.L) goto L02a2;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L02ea;

		L02c7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L02ca:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x32);
			if (this.oCPU.Flags.GE) goto L02e7;

			this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))] = 0;
			goto L02c7;

		L02e7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L02ea:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x50);
			if (this.oCPU.Flags.GE) goto L02f7;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L02ca;

		L02f7:
			this.oParent.GameState.GameSettingFlags = 0xfa;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x1a30), 0x4e);
			if (this.oCPU.Flags.NE) goto L0309;
			this.oParent.GameState.GameSettingFlags &= 0x7fef;

		L0309:
			// Instruction address 0x0000:0x0311, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Pick your tribe...\n ");

			// Instruction address 0x0000:0x031d, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);
			goto L0358;

		L032f:
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x1502);
			// Instruction address 0x0000:0x033d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x034d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L0358:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.AIOpponentCount;
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L032f;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);
			goto L0392;

		L0369:
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x16d2);
			// Instruction address 0x0000:0x0377, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0387, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L0392:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.AIOpponentCount;
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0369;

			// Instruction address 0x0000:0x03ba, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0x96, 0, 0xa0, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x96, 0);

			// Instruction address 0x0000:0x03c2, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x03d3, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 160, 35, 1);

			oParent.GameState.HumanPlayerID = (short)this.oCPU.AX.Word;

			if (this.oParent.GameState.HumanPlayerID <= this.oParent.GameState.AIOpponentCount)
			{
				oParent.GameState.HumanPlayerID++;
			}
			else
			{
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.AIOpponentCount);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
				oParent.GameState.HumanPlayerID = (short)this.oCPU.AX.Word;
			}

			if (this.oParent.GameState.DifficultyLevel == 0)
			{
				this.oParent.GameState.GameSettingFlags |= 1;
			}

			// Another indexing error. Value this.oParent.GameState.HumanPlayerID is equal
			// to nationality selected and not actual ID, but later in code it is forced to 0-7 by value & 7,
			// so we will use this value instead
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID & 7].CurrentResearchID = -1;

			// Instruction address 0x0000:0x0410, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(50));

			oParent.GameState.NextAnthologyTurn += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L0421:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb222), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xc);
			if (this.oCPU.Flags.L) goto L0421;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x3);

		L0440:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd92a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x5);
			if (this.oCPU.Flags.LE) goto L0440;

			if (this.oParent.GameState.HumanPlayerID == 0)
				goto L0476;

			if (this.oParent.GameState.HumanPlayerID <= 7)
				goto L046a;

			this.oCPU.AX.Word = 0x1;
			goto L046c;

		L046a:
			this.oCPU.AX.Word = 0;

		L046c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oParent.GameState.HumanPlayerID &= 7;
			goto L048b;

		L0476:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0xffff);
			
			// Instruction address 0x0000:0x047f, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(this.oParent.GameState.AIOpponentCount));
			this.oCPU.AX.Word++;
			this.oParent.GameState.HumanPlayerID = (short)this.oCPU.AX.Word;

		L048b:
			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xffff);
			if (this.oCPU.Flags.NE) goto L04c2;

			this.oParent.Overlay_23.F23_0000_0173();

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].LeaderGraphics = (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.HumanPlayerID);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x14e2);
			// Instruction address 0x0000:0x0569, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x19a2)), 
				this.oCPU.AX.Word);
			goto L0569;

		L04c2:
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x0);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			}
			else
			{
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			}
		
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].LeaderGraphics = (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].LeaderGraphics);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x14e2);
			// Instruction address 0x0000:0x04ec, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x19a2)),
				this.oCPU.AX.Word);

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].LeaderGraphics);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x1502);
			// Instruction address 0x0000:0x0509, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)),
				this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].LeaderGraphics);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x14f2);
			// Instruction address 0x0000:0x0526, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba06), 0x0);
			if (this.oCPU.Flags.NE) goto L055b;

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0543, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)));

			// Instruction address 0x0000:0x0553, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "s");

		L055b:
			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0569, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)), 0xba06);

		L0569:
			// Instruction address 0x0000:0x0587, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((ushort)(this.oParent.GameState.HumanPlayerID << 1) + 0x1992)),
				46, 92, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L05b6;

		L0596:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));

		L0599:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x8);
			if (this.oCPU.Flags.GE) goto L05b3;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].UnitsDestroyed[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))] = 0;
			goto L0596;

		L05b3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L05b6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.GE) goto L05cd;
			
			F5_0000_07c7(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);
			goto L0599;

		L05cd:
			F5_0000_0fe6();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oParent.GameState.PlayerFlags = (short)this.oCPU.AX.Word;
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x5;
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].TaxRate = (short)this.oCPU.AX.Word;
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].ScienceTaxRate = (short)this.oCPU.AX.Word;

			if (this.oParent.GameState.DifficultyLevel != 0) goto L05fe;
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins = 50;

		L05fe:
			oParent.GameState.PlayerIdentityFlags = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L0609:
			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].LeaderGraphics >= 8)
			{
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				oParent.GameState.PlayerIdentityFlags |= (short)this.oCPU.AX.Word;
			}
		
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8);
			if (this.oCPU.Flags.L) goto L0609;

			// Instruction address 0x0000:0x062a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x0645, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 150, 0, 170, 200, 0);

			this.oParent.Overlay_23.F23_0000_00d6();

			// Instruction address 0x0000:0x0652, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x066e, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0684, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30b8),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0695, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x35c3);

			// Instruction address 0x0000:0x06a1, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L06b6:
			// Instruction address 0x0000:0x06bd, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L0708;

			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x06d7, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x06e7, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ", ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x2);
			if (this.oCPU.Flags.NE) goto L0708;

			// Instruction address 0x0000:0x0700, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n");

		L0708:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x48);
			if (this.oCPU.Flags.L) goto L06b6;

			// Instruction address 0x0000:0x0719, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "and Roads.\n");

			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			// Instruction address 0x0000:0x0738, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x151a)), 3);

			// Instruction address 0x0000:0x0740, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x0759, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 15);

			// Instruction address 0x0000:0x0761, size: 5
			this.oParent.Segment_1866.F0_1866_260e();
			
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DifficultyLevel & 0xff), 0x1);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x0000:0x0799, size: 5
				this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
					0x50, (ushort)((0x23 * this.oParent.GameState.DifficultyLevel) + 6), 0x35, 0x2f,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
					0x86, 0x14);
			}
			else
			{
				// Instruction address 0x0000:0x0799, size: 5
				this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
					0x15, (ushort)((0x23 * this.oParent.GameState.DifficultyLevel) + 6), 0x35, 0x2f,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
					0x86, 0x14);
			}

			// Instruction address 0x0000:0x07b0, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0088_DrawTextBlock(99, 88, 81, 0);

			// Instruction address 0x0000:0x07b8, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x07bd, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <returns></returns>
		public ushort F5_0000_07c7(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F5_0000_07c7({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x34);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			if (playerID != this.oParent.GameState.HumanPlayerID || this.oParent.GameState.TurnCount == 0)
			{
				this.oParent.GameState.Players[playerID].SpaceshipPopulation = 0;
				this.oParent.GameState.Players[playerID].CumulativeEpicRanking = 0;
				this.oParent.GameState.Players[playerID].DiscoveredTechnologyCount = 0;
				this.oParent.GameState.Players[playerID].ResearchProgress = 0;
				this.oParent.GameState.Players[playerID].Coins = 0;
				this.oParent.GameState.Players[playerID].GovernmentType = 1;
				this.oParent.GameState.Players[playerID].TaxRate = 4;
				this.oParent.GameState.Players[playerID].ScienceTaxRate = 4;

				for (int i = 0; i < 16; i++)
				{
					this.oCPU.SI.Word = (ushort)i;
					this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
					this.oParent.GameState.Players[playerID].Continents[i].Strategy = 0;
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x32), 0x0);

					for (int j = 1; j < 8; j++)
					{
						this.oCPU.SI.Word = (ushort)i;
						this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
						this.oCPU.BX.Word = (ushort)j;
						this.oCPU.CX.Low = 0x5;
						this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

						this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[j].Continents[i].CityCount;

						this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x32),
							this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x32)), this.oCPU.AX.Word));
					}
				}

				this.oParent.GameState.Players[playerID].CityCount = 0;
				this.oParent.GameState.Players[playerID].UnitCount = 0;
				this.oParent.GameState.Players[playerID].LandCount = 1;
				this.oParent.GameState.Players[playerID].SettlerCount = 1;
				this.oParent.GameState.Players[playerID].ContactPlayerCountdown = -1;

				for (int i = 0; i < this.oParent.GameState.Players[playerID].TechnologyAcquiredFrom.Length; i++)
				{
					this.oParent.GameState.Players[playerID].TechnologyAcquiredFrom[i] = -1;
				}

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

			L08a3:
				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
				this.oCPU.SI.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
				this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7), 0xff);
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4), 0x0);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x80);
				if (this.oCPU.Flags.L) goto L08a3;
				this.oCPU.SI.Word = (ushort)playerID;
				this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd20c), 0);
				this.oParent.GameState.Players[playerID].Score = 0;

				this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
				this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
				if (this.oCPU.Flags.NE) goto L08fc;

				// Instruction address 0x0000:0x08f4, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8), 240, 0, 80, 50, 0);

			L08fc:
				// Instruction address 0x0000:0x08ff, size: 5
				this.oParent.Segment_25fb.F0_25fb_3223_ClearStrategicLocations(playerID);
				
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

			L090c:
				this.oCPU.SI.Word = (ushort)playerID;
				this.oCPU.CX.Low = 0x4;
				this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

				this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
				this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
				
				this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] = 0;

				this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
				this.oCPU.CX.Low = 0x4;
				this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

				this.oCPU.BX.Word = (ushort)playerID;
				this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

				this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Diplomacy[playerID] = 0;

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8);
				if (this.oCPU.Flags.L) goto L090c;

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0);

			L0938:
				this.oCPU.AX.Word = 0xa;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
				this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

				this.oParent.GameState.Players[playerID].DiscoveredTechnologyFlags[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] = 0;

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x5);
				if (this.oCPU.Flags.L) goto L0938;

				if (this.oParent.GameState.TurnCount == 0) goto L09c3;
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

			L0960:
				// Instruction address 0x0000:0x0967, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
				this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.E)
					goto L09ba;

				this.oCPU.TESTByte((byte)this.oParent.GameState.TechnologyFirstDiscoveredBy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))], 0x7);
				if (this.oCPU.Flags.E) goto L09ba;
				this.oCPU.AX.Low = (byte)this.oParent.GameState.TechnologyFirstDiscoveredBy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))];
				this.oCPU.AX.High = 0;
				this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x7);
				this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.HumanPlayerID);
				if (this.oCPU.Flags.E) goto L09ba;

				// Instruction address 0x0000:0x099d, size: 5
				this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

				this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.NE) goto L09ba;

				// Instruction address 0x0000:0x09b2, size: 5
				this.oParent.Segment_1ade.F0_1ade_1d2e(playerID,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
					playerID);

			L09ba:
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x48);
				if (this.oCPU.Flags.L) goto L0960;

				L09c3:
				this.oCPU.CMPWord((ushort)playerID, 0x0);
				if (this.oCPU.Flags.NE) goto L09cc;
				goto L0e35;

			L09cc:
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)(playerID & 0xff);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.ActiveCivilizations);
				if (this.oCPU.Flags.NE) goto L09dd;
				goto L0e35;

			L09dd:
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
				this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
				if (this.oCPU.Flags.E) goto L0a59;
				if (this.oParent.GameState.TurnCount != 0) goto L0a4f;

			L09ec:
				// Instruction address 0x0000:0x09f9, size: 5
				this.oParent.GameState.Players[playerID].LeaderGraphics = (short)this.oParent.MSCAPI.RNG.Next(16);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x1);

				if ((this.oParent.GameState.Players[playerID].LeaderGraphics & 7) != playerID)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);
				}

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

			L0a1e:
				if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) != playerID &&
					this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].LeaderGraphics ==
					this.oParent.GameState.Players[playerID].LeaderGraphics)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);
				}

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8);
				if (this.oCPU.Flags.L) goto L0a1e;
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x0);
				if (this.oCPU.Flags.E) goto L09ec;
				goto L0a59;

			L0a4f:
				this.oParent.GameState.Players[playerID].LeaderGraphics ^= 8;

			L0a59:
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0x0);

			L0a5e:
				// Instruction address 0x0000:0x0a62, size: 5
				this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(64));

				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

				// Instruction address 0x0000:0x0a74, size: 5
				this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(34));
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

				// Instruction address 0x0000:0x0a86, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0102(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
				if (this.oCPU.Flags.NE) goto L0a9b;
				this.oCPU.AX.Word = 0x1e;
				goto L0ac7;

			L0a9b:
				// Instruction address 0x0000:0x0abf, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0289(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Position.X,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
					this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Position.Y);

			L0ac7:
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
				if (oParent.GameState.TurnCount != 0) goto L0b16;
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
				goto L0b0e;

			L0ad8:
				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				// Instruction address 0x0000:0x0af2, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0289(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
					this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word);
				if (this.oCPU.Flags.GE) goto L0b0b;
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			L0b0b:
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			L0b0e:
				this.oCPU.AX.Word = (ushort)playerID;
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
				if (this.oCPU.Flags.L) goto L0ad8;

				L0b16:
				// Instruction address 0x0000:0x0b24, size: 5
				this.oParent.VGADriver.F0_VGA_038c_GetPixel(2,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)) + 0x50,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))));
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0x7d0);
				if (this.oCPU.Flags.LE) goto L0b4e;
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
				this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
				if (this.oCPU.Flags.E) goto L0b44;
				goto L0c1b;

			L0b44:
				if (oParent.GameState.TurnCount == 0) goto L0b4e;
				goto L0c1b;

			L0b4e:
				// Instruction address 0x0000:0x0b54, size: 5
				this.oParent.Segment_2aea.F0_2aea_134a(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
				if (this.oCPU.Flags.NE) goto L0b64;
				goto L0a5e;

			L0b64:
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34));
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x5;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xc);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
				this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
				if (this.oCPU.Flags.LE) goto L0b82;
				goto L0a5e;

			L0b82:
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34));
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x6;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.SI.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = 0xa;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
				if (this.oCPU.Flags.GE) goto L0ba2;
				goto L0a5e;

			L0ba2:
				// Instruction address 0x0000:0x0ba8, size: 5
				this.oParent.Segment_2aea.F0_2aea_1942(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

				this.oCPU.BX.Word = this.oCPU.AX.Word;
				//this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

				this.oCPU.AX.Word = (ushort)oParent.GameState.TurnCount;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x4;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x20);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);

				this.oCPU.CMPWord((ushort)this.oParent.GameState.Continents[this.oCPU.BX.Word].BuildSiteCount, this.oCPU.AX.Word);
				if (this.oCPU.Flags.L)
					goto L0a5e;

				if (this.oParent.GameState.Year <= 0)
					goto L0bf7;

				// Instruction address 0x0000:0x0be2, size: 5
				this.oParent.Segment_2aea.F0_2aea_1942(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

				this.oCPU.DI.Word = this.oCPU.AX.Word;
				this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x32)), 0x0);
				if (this.oCPU.Flags.E) goto L0bf7;
				goto L0a5e;

			L0bf7:
				// Instruction address 0x0000:0x0c03, size: 5
				this.oParent.Segment_2aea.F0_2aea_134a(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

				// Instruction address 0x0000:0x0c0c, size: 5
				this.oParent.Segment_2aea.F0_2aea_1894(
					this.oCPU.AX.Word,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

				this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.E) goto L0c1b;
				goto L0a5e;

			L0c1b:
				if (this.oParent.GameState.TurnCount != 0) goto L0c49;
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd76a), 0x0);
				if (this.oCPU.Flags.E) goto L0c49;
				this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[playerID].LeaderGraphics;
				this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
				this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x35da));
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
				this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x35db));
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0x0);

			L0c49:
				if (this.oParent.GameState.TurnCount == 0) goto L0c8e;
				this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[playerID].LeaderGraphics, 0x8);
				if (this.oCPU.Flags.L) goto L0c6f;
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)(playerID & 0xff);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerIdentityFlags);
				if (this.oCPU.Flags.E) goto L0c6f;
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0x7d0);

			L0c6f:
				this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[playerID].LeaderGraphics, 0x8);
				if (this.oCPU.Flags.GE) goto L0c8e;
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)(playerID & 0xff);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerIdentityFlags);
				if (this.oCPU.Flags.NE) goto L0c8e;
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0x7d0);

			L0c8e:
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
				this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
				if (this.oCPU.Flags.E) goto L0cba;
				this.oCPU.SI.Word = (ushort)playerID;
				this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
				this.oCPU.AX.Word = 0x3a;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
					(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1516));
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x3);
				this.oParent.GameState.Players[playerID].ScienceTaxRate = (short)this.oCPU.AX.Word;
				this.oCPU.AX.Word = 0x9;
				this.oCPU.AX.Word -= (ushort)this.oParent.GameState.Players[playerID].ScienceTaxRate;
				this.oParent.GameState.Players[playerID].TaxRate = (short)this.oCPU.AX.Word;

			L0cba:
				this.oCPU.AX.Word = 0x32;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.DifficultyLevel);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x15e);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
				if (this.oCPU.AX.Word < this.oParent.GameState.TurnCount) goto L0cd3;
				if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) < 0x7d0) goto L0d12;

			L0cd3:
				if (playerID == this.oParent.GameState.HumanPlayerID) goto L0d12;

				this.oParent.GameState.Players[playerID].LeaderGraphics ^= 8;
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)(playerID & 0xff);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
				oParent.GameState.ActiveCivilizations &= (short)this.oCPU.AX.Word;
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, 0x1);

				if (this.oCPU.AX.Word == (ushort)this.oParent.GameState.ActiveCivilizations)
				{
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 1);
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb884, 1);
				}

				this.oCPU.AX.Word = 0;
				goto L0e66;

			L0d12:
				this.oCPU.SI.Word = (ushort)playerID;
				this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
				this.oCPU.AX.Word = 0x3a;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
					(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x14e2);
				// Instruction address 0x0000:0x0d26, size: 5
				this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x19a2)),
					this.oCPU.AX.Word);

				this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
				this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
				if (this.oCPU.Flags.NE) goto L0d3f;
				this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982));
				this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x0);
				if (this.oCPU.Flags.NE) goto L0dae;

				L0d3f:
				this.oCPU.SI.Word = (ushort)playerID;
				this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
				this.oCPU.AX.Word = 0x3a;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
					(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x1502);
				// Instruction address 0x0000:0x0d53, size: 5
				this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)),
					this.oCPU.AX.Word);

				this.oCPU.AX.Word = 0x3a;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
					(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x14f2);
				// Instruction address 0x0000:0x0d6a, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

				this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba06), 0x0);
				if (this.oCPU.Flags.NE) goto L0d99;

				// Instruction address 0x0000:0x0d81, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)));

				// Instruction address 0x0000:0x0d91, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "s");

			L0d99:
				this.oCPU.BX.Word = (ushort)playerID;
				this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
				// Instruction address 0x0000:0x0da6, size: 5
				this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)), 0xba06);

			L0dae:
				// Instruction address 0x0000:0x0db7, size: 5
				this.oParent.Segment_2aea.F0_2aea_138c_MapSetCityOwner(playerID,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

				// Instruction address 0x0000:0x0dcb, size: 5
				this.oParent.Segment_1866.F0_1866_0cf5(
					playerID,
					0,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
				
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
				this.oParent.GameState.Players[playerID].XStart = (short)this.oCPU.AX.Word;

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

			L0de4:
				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
				this.oCPU.SI.Word = this.oCPU.AX.Word;
				this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)), 0xff);
				if (this.oCPU.Flags.E) goto L0e20;

				// Instruction address 0x0000:0x0e05, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0289(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
					this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x8);
				if (this.oCPU.Flags.G) goto L0e20;
				
				// Instruction address 0x0000:0x0e18, size: 5
				this.oParent.Segment_1866.F0_1866_0f10(0, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			L0e20:
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x80);
				if (this.oCPU.Flags.L) goto L0de4;

				this.oParent.GameState.Players[playerID].DiscoveredTechnologyCount = 1;

			L0e35:
				for (int i = 0; i < 28; i++)
				{
					this.oParent.GameState.Players[playerID].LostUnits[i] = 0;
					this.oParent.GameState.Players[playerID].ActiveUnits[i] = 0;
					this.oParent.GameState.Players[playerID].UnitsInProduction[i] = 0;
				}
				this.oCPU.AX.Word = 0x1;
			}

		L0e66:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_07c7");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="playerID1"></param>
		public void F5_0000_0e6c(short playerID, short playerID1)
		{
			this.oCPU.Log.EnterBlock($"F5_0000_0e6c({playerID}, {playerID1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			if (playerID == 0 || playerID == this.oParent.GameState.HumanPlayerID)
				goto L0fe1;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L0e91;

		L0e8e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L0e91:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x80);
			if (this.oCPU.Flags.GE) goto L0eb4;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0e8e;
			
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].PlayerID != playerID) goto L0e8e;
			goto L0fe1;

		L0eb4:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x0000:0x0ec1, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)));

			// Instruction address 0x0000:0x0ed1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\ncivilization\ndestroyed\nby ");

			this.oCPU.BX.Word = (ushort)playerID1;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0ee6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			// Instruction address 0x0000:0x0ef6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[playerID] & 0x40) != 0)
			{
				this.oCPU.AX.Word = 0x5;
			}
			else
			{
				this.oCPU.AX.Word = 0x2;
			}
		
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, this.oCPU.AX.Word);

			if (playerID1 == this.oParent.GameState.HumanPlayerID)
			{
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x3);
			}

			// Instruction address 0x0000:0x0f32, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			// Instruction address 0x0000:0x0f3d, size: 5
			this.oParent.Segment_2459.F0_2459_05ee(playerID);
			
			// Instruction address 0x0000:0x0f53, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(13, (byte)playerID, (byte)playerID1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L0f60:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)), 0xff);
			if (this.oCPU.Flags.E) goto L0f85;
			
			// Instruction address 0x0000:0x0f7d, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

		L0f85:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x80);
			if (this.oCPU.Flags.L) goto L0f60;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L0fca;

		L0fa3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L0fa6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x32);
			if (this.oCPU.Flags.GE) goto L0fc7;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))] &= (sbyte)this.oCPU.CX.Low;
			goto L0fa3;

		L0fc7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0fca:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50);
			if (this.oCPU.Flags.GE) goto L0fd7;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L0fa6;

		L0fd7:
			F5_0000_07c7(playerID);

		L0fe1:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_0e6c");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F5_0000_0fe6()
		{
			this.oCPU.Log.EnterBlock("F5_0000_0fe6()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x5e);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x0);

		L0ff3:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x46), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)), 0x10);
			if (this.oCPU.Flags.L) goto L0ff3;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L1010:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)), 0xff);
			if (this.oCPU.Flags.E) goto L1050;
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BP.Word);
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, 0x5a);

			// Instruction address 0x0000:0x103d, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.BP.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x46), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x46))));

		L1050:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L1010;
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);
			goto L1206;

		L1069:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x14);
			if (this.oCPU.Flags.GE) goto L1084;

			// Instruction address 0x0000:0x1077, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "moderate");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			goto L10b5;

		L1084:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x3e7);
			if (this.oCPU.Flags.E) goto L10a1;

			// Instruction address 0x0000:0x1093, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "far away");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2));
			goto L10b5;

		L10a1:
			// Instruction address 0x0000:0x10a9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "isolated");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x4));

		L10b5:
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);

		L10c3:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x10ee, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5)) + this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6)) + this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1101;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))));

		L1101:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)), 0x2);
			if (this.oCPU.Flags.NE) goto L110a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L110a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)), 0xb);
			if (this.oCPU.Flags.NE) goto L1113;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e))));

		L1113:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x8);
			if (this.oCPU.Flags.LE) goto L10c3;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0x0);
			if (this.oCPU.Flags.E) goto L1127;
			this.oCPU.AX.Word = 0x3653;
			goto L112a;

		L1127:
			this.oCPU.AX.Word = 0x365c;

		L112a:
			// Instruction address 0x0000:0x112f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0x1);
			if (this.oCPU.Flags.LE) goto L1153;

			// Instruction address 0x0000:0x1145, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "river valley on a ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2));
			goto L117e;

		L1153:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3);
			if (this.oCPU.Flags.L) goto L116e;

			// Instruction address 0x0000:0x1161, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "grasslands on a ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			goto L117e;

		L116e:
			// Instruction address 0x0000:0x1176, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "plains on a ");

		L117e:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x119a, size: 5
			this.oParent.Segment_2aea.F0_2aea_195d(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x32;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L11da;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L11b4;
			goto L1317;

		L11b4:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L11bc;
			goto L131d;

		L11bc:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L11c4;
			goto L1333;

		L11c4:
			// Instruction address 0x0000:0x11cc, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "large continent.");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2));
			goto L11ea;

		L11da:
			// Instruction address 0x0000:0x11e2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 0x3695);

		L11ea:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L11f8;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);

		L11f8:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x1c), this.oCPU.AX.Word);

		L1203:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L1206:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L120f;
			goto L1338;

		L120f:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)), 0xff);
			if (this.oCPU.Flags.E) goto L1203;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x18);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x1);

		L1241:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L12c7;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)), 0xff);
			if (this.oCPU.Flags.E) goto L12c7;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1274, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x128b, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e)));
			if (this.oCPU.Flags.NE) goto L12c7;

			// Instruction address 0x0000:0x12ae, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L12c7;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

		L12c7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x8);
			if (this.oCPU.Flags.GE) goto L12d3;
			goto L1241;

		L12d3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xa);
			if (this.oCPU.Flags.L) goto L12eb;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x3e7);
			if (this.oCPU.Flags.E) goto L12eb;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Word));

		L12eb:
			// Instruction address 0x0000:0x12f3, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Nearest civilization: ");

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xa);
			if (this.oCPU.Flags.L) goto L1304;
			goto L1069;

		L1304:
			// Instruction address 0x0000:0x130c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "close");
			goto L10b5;

		L1317:
			// Instruction address 0x0000:0x11e2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 0x36a3);

			goto L11ea;

		L131d:
			// Instruction address 0x0000:0x1325, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 0x36b1);

		L1320:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			goto L11ea;

		L1333:
			// Instruction address 0x0000:0x1325, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 0x36c2);

			goto L1320;

		L1338:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);
			goto L13ca;

		L1345:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x0);
			if (this.oCPU.Flags.E) goto L135b;

			// Instruction address 0x0000:0x1353, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "+");

		L135b:
			// Instruction address 0x0000:0x1361, size: 5
			this.oParent.Segment_1ade.F0_1ade_1584(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0);

			this.oCPU.CX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x1376, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));

		L1381:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x1c)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			if (this.oCPU.Flags.G) goto L1345;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x1c)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L13c7;

			// Instruction address 0x0000:0x13a6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "NONE");

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c)), 0xffff);
			if (this.oCPU.Flags.E) goto L13c1;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			if (this.oCPU.Flags.E) goto L13c7;

		L13c1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), this.oCPU.AX.Word);

		L13c7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L13ca:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.GE) goto L144c;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)), 0xff);
			if (this.oCPU.Flags.E) goto L13c7;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x13fb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Skills: ");

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BP.Word);
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, 0x1c);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word));
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.LE) goto L1444;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word), 0x3));
			
			// Instruction address 0x0000:0x142c, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				0,
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			// Instruction address 0x0000:0x143c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Settlers+");

		L1444:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x0);
			goto L1381;

		L144c:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c));
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_0fe6");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1455()
		{
			this.oCPU.Log.EnterBlock("F5_0000_1455()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1467, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(7, 1);

			// Instruction address 0x0000:0x147c, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x36ff, 0);

			// Instruction address 0x0000:0x14a4, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0xa0, 0x32, 0xa0, 0x96,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				0xa0, 0x32);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L14b1:
			// Instruction address 0x0000:0x14cb, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((0x2a * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))) + 0xa0),
				0x8e, 0x29, 0x3a);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdf62), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x3);
			if (this.oCPU.Flags.L) goto L14b1;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L14ef;
			goto L1637;

		L14ef:
			// Instruction address 0x0000:0x14f7, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x3709, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L156c;

		L1506:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb884));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb886), this.oCPU.AX.Word);

		L151c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L151f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x10);
			if (this.oCPU.Flags.GE) goto L1569;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x6);
			if (this.oCPU.Flags.GE) goto L1532;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3e), 0x0);
			if (this.oCPU.Flags.E) goto L1538;

		L1532:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.NE) goto L1506;

		L1538:
			// Instruction address 0x0000:0x154f, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) << 4),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4),
				0x10, 0x10);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xb886), this.oCPU.AX.Word);
			goto L151c;

		L1569:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L156c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xa);
			if (this.oCPU.Flags.GE) goto L1579;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L151f;

		L1579:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L15ec;

		L1580:
			// Instruction address 0x0000:0x15a4, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4) - ((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 1) << 3)) + 8),
				0xb8, 8, 8);

		L159f:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xd294), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L15bf:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x4);
			if (this.oCPU.Flags.GE) goto L15e9;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.GE) goto L1580;

			// Instruction address 0x0000:0x15a4, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 1) << 3) + (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4)),
				0xb0, 8, 8);
			goto L159f;

		L15e9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L15ec:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.GE) goto L15f9;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L15bf;

		L15f9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L1603;

		L1600:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L1603:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4);
			if (this.oCPU.Flags.L) goto L160c;
			goto L16b3;

		L160c:
			// Instruction address 0x0000:0x1624, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4) + 0x80),
				0xb0, 0x10, 0x10);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd2d4), this.oCPU.AX.Word);
			goto L1600;

		L1637:
			// Instruction address 0x0000:0x163f, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(3, 0, 0, 0x3714, 1);

			// Instruction address 0x0000:0x165f, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19fc),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L166c:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			// Instruction address 0x0000:0x1687, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(3, this.oCPU.SI.Word, 0, 0x10, 0x10);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xb886), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x169e, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(3, this.oCPU.SI.Word, 0x10, 0x10, 0x10);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xb888), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xc);
			if (this.oCPU.Flags.L) goto L166c;

		L16b3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L16f5;

			// Instruction address 0x0000:0x16c2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x3720, 0);

			// Instruction address 0x0000:0x16d2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x372a, 0xbdee);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L16df:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xbdf4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6b34), this.oCPU.AX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x30);
			if (this.oCPU.Flags.L) goto L16df;

		L16f5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L16fa:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			
			// Instruction address 0x0000:0x1714, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, 0x30, 0x10, 0x10);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xb27a), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1732, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, (ushort)(this.oCPU.SI.Word + 0x80), 0x60, 0x10, 0x10);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xb29a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L16fa;
			
			// Instruction address 0x0000:0x1758, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, 0x30, 0x20, 0x10, 0x10);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb2ba, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L1768:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			
			// Instruction address 0x0000:0x1782, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, 0x40, 0x10, 0x10);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6dfe), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x179c, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, 0x50, 0x10, 0x10);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6e1e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x10);
			if (this.oCPU.Flags.L) goto L1768;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L17b6:
			this.oCPU.AX.Word = 0x7;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0xa0);
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			// Instruction address 0x0000:0x17d7, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, 0, 7, 15);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xd21c), this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x17f4, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, 16, 7, 15);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xd244), this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x1811, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, 0x20, 7, 15);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xd26c), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x14);
			if (this.oCPU.Flags.L) goto L17b6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L182b:
			// Instruction address 0x0000:0x1843, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4) + 0x50),
				0x80, 0x10, 0x10);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7eec), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4);
			if (this.oCPU.Flags.L) goto L182b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L1862:
			// Instruction address 0x0000:0x1877, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4),
				0x20, 16, 16);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd4ce), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x7);
			if (this.oCPU.Flags.L) goto L1862;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6e92);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4dc, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L189c:
			// Instruction address 0x0000:0x18bf, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) & 3) << 3) + 0x81),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) & 4) << 1) + 0x21),
				7, 7);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd4de), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L189c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L18de:
			// Instruction address 0x0000:0x18f6, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 3),
				0x80, 8, 16);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6e96), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x9);
			if (this.oCPU.Flags.L) goto L18de;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L1915:
			// Instruction address 0x0000:0x192b, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4) + 1),
				0x71, 15, 15);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd4ee), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x10);
			if (this.oCPU.Flags.L) goto L1915;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L194a:
			// Instruction address 0x0000:0x1960, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4) + 1),
				0x61, 15, 15);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd50e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L194a;
			
			// Instruction address 0x0000:0x198b, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, 0x99, 0x29, 7, 7);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb880, this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x19aa, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, 0xb0, 0x80, 0x14, 9);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdf0c, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L1a0b;

		L19bc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L19bf:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x1c);
			if (this.oCPU.Flags.GE) goto L1a08;
			
			// Instruction address 0x0000:0x19ee, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) % 0x14) << 4) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) / 0x14) << 4) + 0x81),
				15, 15);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd54e), this.oCPU.AX.Word);
			goto L19bc;

		L1a08:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L1a0b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.L) goto L1a14;
			goto L1aeb;

		L1a14:
			// Instruction address 0x0000:0x1a32, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0xa0, 0x140, 0x20,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x80);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)), 0xf);
			if (this.oCPU.Flags.NE) goto L1a69;
			// Instruction address 0x0000:0x1a61, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4), 0, 128, 320, 32, 15, 11);

		L1a69:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)), 0x7);
			if (this.oCPU.Flags.NE) goto L1a98;
			// Instruction address 0x0000:0x1a90, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4), 0, 128, 320, 32, 7, 3);

		L1a98:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word <<= 1;
			// Instruction address 0x0000:0x1ab8, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4), 0, 128, 320, 32, 10,
				(byte)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1946)));

			// Instruction address 0x0000:0x1adb, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4), 0, 128, 320, 32, 2,
				(byte)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1956)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L19bf;

		L1aeb:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_1455");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1af6()
		{
			this.oCPU.Log.EnterBlock("F5_0000_1af6()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x12);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1b07, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(2, 1);

			// Instruction address 0x0000:0x1b17, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "govt0a.pic");

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Low);
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L1b40;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x33);
			goto L1b58;

		L1b40:
			// Instruction address 0x0000:0x1b48, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(oParent.GameState.HumanPlayerID, 0x14);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb), 0x6d);
			}

		L1b58:
			// Instruction address 0x0000:0x1b60, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0);

			// Instruction address 0x0000:0x1b84, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0xa0, 0x3c,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				0xa0, 0x8c);

			// Instruction address 0x0000:0x1b95, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_1af6");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1ba2()
		{
			this.oCPU.Log.EnterBlock("F5_0000_1ba2()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType, 0x0);
			if (this.oCPU.Flags.NE) goto L1bb9;
			goto L1d15;

		L1bb9:
			// Instruction address 0x0000:0x1bb9, size: 5
			this.oParent.Segment_1ade.F0_1ade_0394();

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1bcc, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)));

			// Instruction address 0x0000:0x1bdc, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " government\nchanged to ");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1bf8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1966)));

			// Instruction address 0x0000:0x1c08, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n");

			this.oParent.Overlay_21.F21_0000_0000(-2);
			
			// Instruction address 0x0000:0x1c1c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x1c38, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 100, 320, 100, 15);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x6);

			// Instruction address 0x0000:0x1c58, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x375a, 160, 102, 0);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L1c87;

		L1c87:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x4);
			if (this.oCPU.Flags.GE) goto L1cfd;

			// Instruction address 0x0000:0x1cbb, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				(ushort)((0x28 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))) + 0xa0),
				0x8c, 0x28, 0x3c,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(ushort)((0x50 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))) + 0x14), 0x76);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1cd0, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2fac)));

			// Instruction address 0x0000:0x1cdc, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05), 0x0);

			// Instruction address 0x0000:0x1c7c, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06,
				(80 * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))) + 40,
				((this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) & 1) != 0) ? 186 : 180, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			goto L1c87;

		L1cfd:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);

			// Instruction address 0x0000:0x1d06, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x1d0b, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x0000:0x1d10, size: 5
			this.oParent.Segment_1ade.F0_1ade_03bf();

		L1d15:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_1ba2");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F5_0000_1d1a(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F5_0000_1d1a({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);

			this.oParent.GameState.Players[playerID].SpaceshipETAYear = -1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L1d5d;

		L1d32:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L1d35:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xc);
			if (this.oCPU.Flags.GE) goto L1d5a;
			this.oCPU.AX.Word = 0xb4;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.WriteUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x16e0), 0xff);
			goto L1d32;

		L1d5a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L1d5d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xf);
			if (this.oCPU.Flags.GE) goto L1d6a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L1d35;

		L1d6a:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_1d1a");
		}
	}
}
