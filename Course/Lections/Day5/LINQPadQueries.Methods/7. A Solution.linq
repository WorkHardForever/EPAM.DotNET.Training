<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Security.AccessControl</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

void Test (DateTime? eventTime = null)
{
	eventTime = eventTime.HasValue ? eventTime.Value : DateTime.Now;
	//eventTime = eventTime ?? DateTime.Now;
	eventTime.Dump();
}

void Main()
{
	Test();
}