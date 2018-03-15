using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Runtime.InteropServices;

public class HandleUtility : MonoBehaviour {

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern int GetHandle();
    
	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern void Initialize();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern int GetAccel();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern int GetBrake();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern int GetClutch();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool Spring (int offset, int saturationPercentage, int coefficientPercentage);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool StopSpring();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool ConstantForce (int power);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool StopConstantForce ();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool DirtRoadEffect (int power);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool StopDirtRoadEffect ();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool Damper (int power);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool StopDamper();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool SideCollision (int power);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool FrontalCollision (int power);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool PlayLEDs (float currentRPM, float rpmFirstLEDTurnsOn, float rpmRedLine);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool BumpyRoadEffect (int power);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool StopBumpyRoadEffect();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool SlipperyRoadEffect(int power);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool StopSlipperyRoadEffect();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool SetOperatingRange (int range);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern int GetShifterMode();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ShutdownSteering ();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool IsConnected();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool IsPlaying (int forceType);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool HasForceFeedback ();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern int GetNonLinearValue(int nonLinCoeff, int inputValue);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool CarAirborneEffect ();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool StopCarAirborneEffect ();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool SoftstopForce(int usableRange);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool StopSoftstopForce ();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool PlaySurfaceEffect (int type, int magnitudePercentage, int period);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool StopSurfaceEffect ();

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool GetButton (int buttonId);

	[DllImport("Handle", CallingConvention = CallingConvention.Cdecl)]
	public static extern int GetPOV ();

	public const int FORCE_SPRING = 0;
	public const int FORCE_CONSTANT = 1;
	public const int FORCE_DAMPER = 2;
	public const int FORCE_SIDE_COLLISION = 3;
	public const int FORCE_FRONTAL_COLLISION = 4;
	public const int FORCE_DIRT_ROAD = 5;
	public const int FORCE_BUMPY_ROAD = 6;
	public const int FORCE_SLIPPERY_SPRING = 7;
	public const int FORCE_SURFACE_EFFECT = 8;
	public const int FORCE_CAR_AIRBORNE = 11;
	public const int FORCE_SOFT_STOP = 10;
	public const int FORCE_NONE = -1;

	public const int PERIODIC_TYPE_NONE = -1;
	public const int PERIODIC_TYPE_SINE = 0;
	public const int PERIODIC_TYPE_TRIANGLE = 2;
	public const int PERIODIC_TYPE_SQUARE = 1;

	public const int POV_UP = 0;
	public const int POV_RIGHT_UP = 4500;
	public const int POV_RIGHT = 9000;
	public const int POV_RIGHT_DOWN = 13500;
	public const int POV_DOWN = 18000;
	public const int POV_LEFT_DOWN = 22500;
	public const int POV_LEFT = 27000;
	public const int POV_LEFT_UP = 31500;

	public const int BUTTON_CROSS = 0;
	public const int BUTTON_SQUARE = 1;
	public const int BUTTON_CIRCLE = 2;
	public const int BUTTON_TRIANGLE = 3;
	public const int BUTTON_BACK_RIGHT = 4;
	public const int BUTTON_BACK_LEFT = 5;
	public const int BUTTON_R2 = 6;
	public const int BUTTON_L2 = 7;
	public const int BUTTON_SHARE = 8;
	public const int BUTTON_OPTION = 9;
	public const int BUTTON_R3 = 10;
	public const int BUTTON_L3 = 11;
	public const int BUTTON_UP = 19;
	public const int BUTTON_DOWN = 20;
	public const int BUTTON_RED_DIAL_RIGHT = 21;
	public const int BUTTON_RED_DIAL_LEFT = 22;
	public const int BUTTON_RETURN = 23;
	public const int BUTTON_PS = 24;
}
