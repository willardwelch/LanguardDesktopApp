﻿using System;
                var dataset = ConnectData.insert_info.sp_selectBrigadebyBde(bdeID);

                    this.cmbHideBrigade.ValueMember = "ID";

                    this.cmbHideBrigade.Refresh();
                var dataset = ConnectData.insert_info.sp_selectUnitbyID(bdeID, UnitdID);

              
                var dataset = ConnectData.insert_info.sp_selectCoybyID(UnitdID, bdeID, CoyID);

                cmbhidecoy.DisplayMember = "Company";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbBrigade_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadUnit();
        }

        private void cmbUnit1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadCoy();
        }
    }