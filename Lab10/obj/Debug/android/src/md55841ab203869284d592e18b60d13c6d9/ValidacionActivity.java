package md55841ab203869284d592e18b60d13c6d9;


public class ValidacionActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Lab10.ValidacionActivity, Lab10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ValidacionActivity.class, __md_methods);
	}


	public ValidacionActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ValidacionActivity.class)
			mono.android.TypeManager.Activate ("Lab10.ValidacionActivity, Lab10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
