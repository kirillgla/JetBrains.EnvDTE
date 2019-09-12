﻿namespace EnvDTE
{
	public interface CodeDelegate
	{
		DTE DTE { get; }
		CodeElements Collection { get; }
		string this[] { get; set; }
		string FullName { get; }
		ProjectItem ProjectItem { get; }
		vsCMElement Kind { get; }
		bool IsCodeType { get; }
		vsCMInfoLocation InfoLocation { get; }
		CodeElements Children { get; }
		string Language { get; }
		TextPoint StartPoint { get; }
		TextPoint EndPoint { get; }
		object ExtenderNames { get; }
		string ExtenderCATID { get; }
		object Parent { get; }
		CodeNamespace Namespace { get; }
		CodeElements Bases { get; }
		CodeElements Members { get; }
		vsCMAccess Access { set; get; }
		CodeElements Attributes { get; }
		string DocComment { get; set; }
		string Comment { get; set; }
		CodeElements DerivedTypes { get; }
		CodeClass BaseClass { get; }
		CodeTypeRef Type { get; set; }
		CodeElements Parameters { get; }
		object get_Extender(string ExtenderName);
		TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		CodeElement AddBase(object Base, object Position);
		CodeAttribute AddAttribute(string Name, string Value, object Position);
		void RemoveBase(object Element);
		void RemoveMember(object Element);
		bool get_IsDerivedFrom(string FullName);
		string get_Prototype(int Flags = 0);
		CodeParameter AddParameter(string Name, object Type, object Position);
		void RemoveParameter(object Element);
	}
}
