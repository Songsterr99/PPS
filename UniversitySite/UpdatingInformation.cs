///////////////////////////////////////////////////////////
//  UpdatingInformation.cs
//  Implementation of the Class <<control>> UpdatingInformation
//  Generated by Enterprise Architect
//  Created on:      23-���-2018 12:50:35
//  Original author: Veronika
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UniversitySite {
	/// <summary>
	/// ���������� ���������� � ����� ������
	/// </summary>
	public static class  UpdatingInformation {

        /// 
        /// <param name="name">Name of leader</param>
        /// <param name="year">Start date of working</param>
        public static bool UpdateHistory(string name, int year){
            string sql = String.Format("UPDATE 'LEADER' SET STARTDATE= {0} WHERE NAME= \"{1}\";", year, name);
            return (GetInfo.ExecuteReadSql(sql));
		}

        /// 
        /// <param name="score">Passing score on subject</param>
        /// <param name="name">Name of subject</param>
        public static bool UpdateMaxScore(string name, int score){
            string sql = String.Format("UPDATE 'SUBJECT' SET PASSINGSCORE= {0} WHERE SUBJNAME= \"{1}\";", score, name);
            return (GetInfo.ExecuteReadSql(sql));
		}

        /// 
        /// <param name="amount">Amount of people in plan</param>
        /// <param name="name">Name of speciality</param>
        public static bool UpdatePlanOfAdmission(string name, int amount){
            string sql = String.Format("UPDATE 'PLANOFADMISSION' SET AMOUNT= {0} WHERE SPECIID= " +
                "(SELECT SPECID FROM 'SPECIALITY' WHERE SNAME = \"{1}\") ;", amount, name);
            return (GetInfo.ExecuteReadSql(sql));
        }

	}//end <<control>> UpdatingInformation

}//end namespace ManageInfoClassDiagram