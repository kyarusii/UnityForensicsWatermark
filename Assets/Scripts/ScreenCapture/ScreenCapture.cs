namespace FW
{
	public sealed class ScreenCapture
	{
		private static readonly object syncObject = new object();
		private static ScreenCapture instance = default;

		public static ScreenCapture Instance {
			get
			{
				lock (syncObject)
				{
					if (instance == null)
					{
						instance = new ScreenCapture();
					}
				}

				return instance;
			}
		}

		private ScreenCaptureBase capture;

		public void Initialize()
		{
#if UNITY_EDITOR_WIN
			capture = new ScreenCaptureEditor();
#elif UNITY_EDITOR_MAC
			capture = new ScreenCaptureEditor();
#elif UNITY_EDITOR_LINUX
			capture = new ScreenCaptureEditor();	
#elif UNITY_STANDALONE_WIN
			capture = new ScreenCaptureWin();
#elif UNITY_STANDALONE_OSX
			capture = new ScreenCaptureMac();
#elif UNITY_STANDALONE_LINUX
			capture = new ScreenCaptureLinux();
#elif UNITY_ANDROID
			capture = new ScreenCaptureAndroid();
#elif UNITY_IOS
			capture = new ScreenCaptureIOS();
#endif
		}
	}

	public abstract class ScreenCaptureBase { }

	public sealed class ScreenCaptureAndroid : ScreenCaptureBase { }

	public sealed class ScreenCaptureIOS : ScreenCaptureBase { }

	public class ScreenCaptureWindows : ScreenCaptureBase { }

	public class ScreenCaptureMac : ScreenCaptureBase { }
	
	public class ScreenCaptureEditor : ScreenCaptureBase { }
}