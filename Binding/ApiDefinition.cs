using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace TargetBinding
{
	// Delegates bound to objective C blocks

	public delegate void LoadedCallback (string content);
	public delegate bool LogicDelegate (double inAppDuration, double totalDuration, NSMutableDictionary data);
	public delegate void MediaCallback (ADBMediaState mediaState);
	public delegate void AudienceCallback (NSDictionary response);

	// ADBMobile class

	[BaseType (typeof (NSObject))]
	interface ADBMobile 
	{

		[Static, Export ("version")]
		string Version ();

		[Static, Export ("privacyStatus")]
		ADBMobilePrivacyStatus privacyStatus();

		[Static, Export ("setPrivacyStatus:")]
		void SetPrivacyStatus(ADBMobilePrivacyStatus status);

		[Static, Export ("lifetimeValue")]
		NSDecimalNumber LifetimeValue ();

		[Static, Export ("userIdentifier")]
		string UserIdentifier();

		[Static, Export ("setUserIdentifier:")]
		bool SetUserIdentifier (string identifier);

		[Static, Export ("debugLogging")]
		bool DebugLogging();

		[Static, Export ("setDebugLogging:")]
		void SetDebugLogging(bool debug);

		[Static, Export ("keepLifecycleSessionAlive")]
		void KeepLifecycleSessionAlive();

		[Static, Export ("collectLifecycleData")]
		void CollectLifecycleData();

		[Static, Export ("overrideConfigPath:")]
		void OverrideConfigPath (string path);

		#region Analytics

		[Static, Export ("trackState:data:")]
		void TrackState(string state, NSDictionary data);

		[Static, Export ("targetCreateRequestWithName:defaultContent:parameters:")]
		ADBTargetLocationRequest TargetCreateRequestWithName(string name, string defaultContent, NSDictionary parameters);

		[Static, Export ("trackAction:data:")]
		void TrackAction(string action, NSDictionary data);

		[Static, Export ("trackActionFromBackground:data:")]
		void TrackActionFromBackground(string action, NSDictionary data);

		[Static, Export ("trackLocation:data:")]
		void TrackLocation(CLLocation location, NSDictionary data);

		[Static, Export ("trackBeacon:data:")]
		void TrackBeacon(CLBeacon beacon, NSDictionary data);

		[Static, Export ("trackingClearCurrentBeacon")]
		void TrackingClearCurrentBeacon();

		[Static, Export ("trackLifetimeValueIncrease:data:")]
		void TrackLifetimeValueIncrease(NSDecimalNumber amount, NSDictionary data);

		[Static, Export ("trackTimedActionStart:data:")]
		void TrackTimedActionStart(string action, NSDictionary data);

		[Static, Export ("trackTimedActionUpdate:data:")]
		void TrackTimedActionUpdate(string action, NSDictionary data);

		[Static, Export ("trackTimedActionEnd:logic:")]
		void TrackTimedActionEnd (string action, LogicDelegate logicDelegate);

		[Static, Export ("trackingTimedActionExists:")]
		bool TrackingTimedActionExists (string action);

		[Static, Export ("trackingIdentifier")]
		string TrackingIdentifier();

		[Static, Export ("trackingSendQueuedHits")]
		void TrackingSendQueuedHits();

		[Static, Export ("trackingClearQueue")]
		void TrackingClearQueue();

		[Static, Export ("trackingGetQueueSize")]
		int TrackingGetQueueSize();

		#endregion

		#region Media Analytics

		[Static, Export ("mediaCreateSettingsWithName:length:playerName:playerID:")]
		ADBMediaSettings MediaCreateSettings(string name, double length, string playerName, string playerID);

		[Static, Export ("mediaAdCreateSettingsWithName:length:playerName:parentName:parentPod:parentPosition:CPM")]
		ADBMediaSettings MediaAdCreateSettings(string name, double length, string playerName, string parentName, string parentPod, double parentPodPosition, string CPM);

		[Static, Export ("mediaOpenWithSettings:")]
		void MediaOpenWithSettings (MediaCallback mediaCallback);

		[Static, Export ("mediaClose:")]
		void MediaClose(string name);

		[Static, Export ("mediaPlay:offset:")]
		void MediaPlay(string name, double offset);

		[Static, Export ("mediaComplete:offset:")]
		void MediaComplete(string name, double offset);

		[Static, Export ("mediaStop:offset:")]
		void MediaStop(string name, double offset);

		[Static, Export ("mediaClick:offset:")]
		void MediaClick(string name, double offset);

		[Static, Export ("mediaTrack:data:")]
		void MediaTrack(string name, NSDictionary data);

		#endregion

		#region Target

		[Static, Export ("targetLoadRequest:callback:")]
		void TargetLoadRequest(ADBTargetLocationRequest request, LoadedCallback loadedCallback);

		[Static, Export ("targetCreateRequestWithName:defaultContent:parameters:")]
		ADBTargetLocationRequest TargetCreateRequest(string name, string defaultContent, NSDictionary parameters);

		[Static, Export ("targetCreateOrderConfirmRequestWithName:orderId:orderTotal:productPurchasedId:parameters:")]
		ADBTargetLocationRequest TargetCreateOrderConfirmRequest(string name, string orderId, string orderTotal, string productPurchasedId, NSDictionary parameters);

		[Static, Export ("targetClearCookies")]
		void TargetClearCookies();

		#endregion

		#region Audience Manager

		[Static, Export ("audienceVisitorProfile")]
		NSDictionary AudienceVisitorProfile();

		[Static, Export ("audienceDpid")]
		NSString AudienceDpid();

		[Static, Export ("audienceDpuuid")]
		NSString AudienceDpuuid();

		[Static, Export ("audienceSignalWithData:")]
		void AudienceSignalWithData(AudienceCallback callback);

		[Static, Export ("audienceReset")]
		void AudienceReset();

	}


	// ADBTargetLocationRequest class

	[BaseType (typeof (NSObject))]
	interface ADBTargetLocationRequest 
	{

		[Export ("name")]
		string Name { get; set; }

		[Export ("defaultContent")]
		string DefaultContent { get; set; }

		[Export ("parameters")]
		NSMutableDictionary Parameters { get; set; }
	}

	#region ADBMediaSettings

	[BaseType (typeof (NSObject))]
	interface ADBMediaSettings 
	{

		[Export ("segmentByMilestones")]
		bool SegmentByMilestones { get; set; }

		[Export ("segmentByOffsetMilestones")]
		bool SegmentByOffsetMilestones { get; set; }

		[Export ("length")]
		double Length { get; set; }

		[Export ("channel")]
		string Channel { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("playerName")]
		string PlayerName { get; set; }

		[Export ("playerID")]
		string PlayerID { get; set; }

		[Export ("milestones")]
		string Milestones { get; set; }

		[Export ("offsetMilestones")]
		string OffsetMilestones { get; set; }

		[Export ("trackSeconds")]
		int TrackSeconds { get; set; }

		[Export ("completeCloseOffsetThreshold")]
		int CompleteCloseOffsetThreshold { get; set; }

		// Media Ad settings

		[Export ("isMediaAd")]
		bool IsMediaAd { get; set; }

		[Export ("parentPodPosition")]
		double ParentPodPosition { get; set; }

		[Export ("CPM")]
		string CPM { get; set; }

		[Export ("parentName")]
		string ParentName { get; set; }

		[Export ("parentPod")]
		string ParentPod { get; set; }
	}

	#endregion

	#region ADBMediaState

	[BaseType (typeof (NSObject))]
	public interface ADBMediaState
	{

		[Export ("ad")]
		bool Ad { get; set; }

		[Export ("clicked")]
		bool Clicked { get; set; }

		[Export ("complete")]
		bool Complete { get; set; }

		[Export ("eventFirstTime")]
		bool EventFirstTime { get; set; }

		[Export ("length")]
		double Length { get; set; }

		[Export ("offset")]
		double Offset { get; set; }

		[Export ("segmentLength")]
		double SegmentLength { get; set; }

		[Export ("timePlayed")]
		double TimePlayed { get; set; }

		[Export ("timePlayedSinceTrack")]
		double TimePlayedSinceTrack { get; set; }

		[Export ("timestamp")]
		double TimeStamp { get; set; }

		[Export ("openTime")]
		NSDate OpenTime { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("playerName")]
		string PlayerName { get; set; }

		[Export ("mediaEvent")]
		string MediaEvent { get; set; }

		[Export ("segment")]
		string Segment { get; set; }

		[Export ("milestone")]
		int Milestone { get; set; }

		[Export ("offsetMilestone")]
		int OffsetMilestone { get; set; }

		[Export ("segmentNum")]
		int SegmentNum { get; set; }

		[Export ("eventType")]
		int EventType { get; set; }
	}

	#endregion

	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//


	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//
}

