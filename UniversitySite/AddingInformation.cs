///////////////////////////////////////////////////////////
//  AddingInformation.cs
//  Implementation of the Class <<control>> AddingInformation
//  Generated by Enterprise Architect
//  Created on:      23-���-2018 12:50:30
//  Original author: Veronika
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace UniversitySite {
	/// <summary>
	/// ���������� ���������� � ���� ������
	/// </summary>
	public static class  AddingInformation {

        public static bool AddInfo(Department dep, Speciality spec, Faculty fac,Head head, string address, string phone, string site, int year, FormOfEducation form)
        {
            if (!AddContactInfo(phone, site, address, spec))
                return false;
            if (!AddEducationalUnit(dep, fac, spec, form))
                return false;
            if (!AddHead(head, dep, fac, spec, year))
                return false;

            return true;
        }


        /// 
        /// <param name="phone">Phone number of university</param>
        /// <param name="site">Website of university</param>
        /// <param name="address">Address of university</param>
        public static bool AddContactInfo(string phone, string site, string address, Speciality spec){
            try
            {
                string sql = String.Format("INSERT INTO 'CONTACTINFO' (ADDRESS, PHONENUMBER, WEBSITE, SPECID) VALUES ('{0}', '{1}', '{2}', {3});",
                    address, phone, site, spec.Code);
                if (!GetInfo.ExecuteReadSql(sql))
                    return false;
            }
            catch (SQLiteException ex)
            {
                return false;
            }

            return true;
        }

        /// 
        /// <param name="dep">Department of university</param>
        /// <param name="fac">Faculty of university</param>
        /// <param name="spec">Speciality of university</param>
        /// <param name="form">Form of education</param>
        public static bool AddEducationalUnit(Department dep, Faculty fac, Speciality spec, FormOfEducation form){
            try
            {
                string sql = String.Format("INSERT INTO 'DEPARTMENT' (DEPCODE, DEPNAME, DEPSHORTNAME) VALUES ({0}, '{1}', '{2}');",
                    dep.Code, dep.Name, dep.ShortName);
                if (!GetInfo.ExecuteReadSql(sql))
                    return false;
                sql = String.Format("INSERT INTO 'FACULTY' (FACCODE, FACNAME, FACSHORTNAME, DEPRID) VALUES ({0}, '{1}', '{2}', {3});",
                    fac.Code, fac.Name, fac.ShortName, dep.Code);
                if (!GetInfo.ExecuteReadSql(sql))
                    return false;
                sql = String.Format("INSERT INTO 'SPECIALITY' (SCODE, SNAME, SSHORTNAME, FAID, FORMID, DEPARID) VALUES ({0}, '{1}', '{2}', {3}, {4}, {5});",
                    spec.Code, spec.Name, spec.ShortName, fac.Code, (int)form, dep.Code);
                if (!GetInfo.ExecuteReadSql(sql))
                    return false;
            }
            catch(SQLiteException ex)
            {
                return false;
            }

            return true;
		}

        /// 
        /// <param name="item">Head of the university</param>
        /// <param name="dep">Department of university</param>
        /// <param name="fac">Faculty of university</param>
        /// <param name="spec">Speciality of university</param>
        public static bool AddHead(Head item, Department dep, Faculty fac, Speciality spec, int year)
        {
            try
            {
                string sql = String.Format("INSERT INTO 'LEADER' (NAME, SCDEGREE, SCRANK, STARTDATE,SID,DPID,FCID) VALUES ('{0}', '{1}', '{2}', {3}, {4}, {5},{6});",
                    item.Name, item.ScDegree, item.ScRank, year, spec.Code, dep.Code, fac.Code);
                if (!GetInfo.ExecuteReadSql(sql))
                    return false;
            }
            catch (SQLiteException ex)
            {
                return false;
            }

            return true;
        }

	}//end <<control>> AddingInformation

}//end namespace ManageInfoClassDiagram