{
	"version":"LAYASCENE3D:02",
	"data":{
		"type":"Scene3D",
		"props":{
			"name":"SampleScene",
			"ambientColor":[
				0.212,
				0.227,
				0.259
			],
			"reflectionDecodingFormat":1,
			"reflection":"Assets/Scenes/SampleSceneGIReflection.ltcb",
			"reflectionIntensity":1,
			"ambientMode":1,
			"ambientSphericalHarmonics":[
				0.1678838,
				-0.01659165,
				-0.01137983,
				0.00656961,
				0.004985159,
				-0.008635049,
				0.009734819,
				-0.01030053,
				0.02333619,
				0.2107363,
				0.02701665,
				-0.0188861,
				0.01090373,
				0.008416965,
				-0.01457904,
				0.01416337,
				-0.01572322,
				0.03351215,
				0.2899413,
				0.1099665,
				-0.0348094,
				0.02009422,
				0.01630473,
				-0.02824404,
				0.01814265,
				-0.02374644,
				0.04080036
			],
			"ambientSphericalHarmonicsIntensity":1,
			"lightmaps":[],
			"enableFog":false,
			"fogStart":0,
			"fogRange":300,
			"fogColor":[
				0.5,
				0.5,
				0.5
			]
		},
		"child":[
			{
				"type":"Camera",
				"instanceID":0,
				"props":{
					"name":"Main Camera",
					"active":true,
					"isStatic":false,
					"layer":0,
					"position":[
						0,
						1.97,
						-14.96
					],
					"rotation":[
						0,
						1,
						0,
						0
					],
					"scale":[
						1,
						1,
						1
					],
					"clearFlag":1,
					"orthographic":false,
					"orthographicVerticalSize":10,
					"fieldOfView":60,
					"enableHDR":true,
					"nearPlane":0.3,
					"farPlane":1000,
					"viewport":[
						0,
						0,
						1,
						1
					],
					"clearColor":[
						0.7735849,
						0.3872863,
						0.3685475,
						0
					]
				},
				"components":[],
				"child":[]
			},
			{
				"type":"DirectionLight",
				"instanceID":1,
				"props":{
					"name":"Directional Light",
					"active":true,
					"isStatic":false,
					"layer":0,
					"position":[
						0,
						3,
						0
					],
					"rotation":[
						0.1093816,
						0.8754261,
						0.4082179,
						-0.2345697
					],
					"scale":[
						1,
						1,
						1
					],
					"intensity":1,
					"lightmapBakedType":1,
					"color":[
						1,
						0.9568627,
						0.8392157
					]
				},
				"components":[],
				"child":[]
			},
			{
				"type":"MeshSprite3D",
				"instanceID":2,
				"props":{
					"name":"Plane",
					"active":true,
					"isStatic":false,
					"layer":0,
					"position":[
						0,
						0,
						-10
					],
					"rotation":[
						0,
						0,
						0,
						-1
					],
					"scale":[
						1,
						1,
						1
					],
					"meshPath":"Library/unity default resources-Plane.lm",
					"enableRender":true,
					"materials":[
						{
							"type":"Laya.BlinnPhongMaterial",
							"path":"Resources/unity_builtin_extra.lmat"
						}
					]
				},
				"components":[
					{
						"type":"PhysicsCollider",
						"restitution":0,
						"friction":0.5,
						"rollingFriction":0,
						"shapes":[
							{
								"type":"MeshColliderShape",
								"mesh":"Library/unity default resources-Plane.lm"
							}
						],
						"isTrigger":false
					}
				],
				"child":[]
			},
			{
				"type":"MeshSprite3D",
				"instanceID":3,
				"props":{
					"name":"Cube",
					"active":true,
					"isStatic":false,
					"layer":0,
					"position":[
						-0.04,
						3.55,
						-10.96
					],
					"rotation":[
						0,
						0,
						0,
						-1
					],
					"scale":[
						1,
						1,
						1
					],
					"meshPath":"Library/unity default resources-Cube.lm",
					"enableRender":true,
					"materials":[
						{
							"path":"Assets/Materials/Material.lmat"
						}
					]
				},
				"components":[
					{
						"type":"Rigidbody3D",
						"mass":1,
						"isKinematic":false,
						"restitution":0,
						"friction":0.5,
						"rollingFriction":0,
						"linearDamping":0,
						"angularDamping":0,
						"overrideGravity":false,
						"gravity":[
							0,
							0,
							0
						],
						"shapes":[
							{
								"type":"BoxColliderShape",
								"center":[
									0,
									0,
									0
								],
								"size":[
									1,
									1,
									1
								]
							}
						],
						"isTrigger":false,
						"linearFactor":[
							1,
							1,
							1
						],
						"angularFactor":[
							1,
							1,
							1
						]
					}
				],
				"child":[]
			},
			{
				"type":"MeshSprite3D",
				"instanceID":4,
				"props":{
					"name":"Sphere",
					"active":true,
					"isStatic":false,
					"layer":0,
					"position":[
						-1.8,
						11.397,
						-9
					],
					"rotation":[
						0,
						0,
						0,
						-1
					],
					"scale":[
						1,
						1,
						1
					],
					"meshPath":"Library/unity default resources-Sphere.lm",
					"enableRender":true,
					"materials":[
						{
							"path":"Assets/Materials/Material.lmat"
						}
					]
				},
				"components":[
					{
						"type":"Rigidbody3D",
						"mass":1,
						"isKinematic":false,
						"restitution":0,
						"friction":0.5,
						"rollingFriction":0,
						"linearDamping":0,
						"angularDamping":0,
						"overrideGravity":false,
						"gravity":[
							0,
							0,
							0
						],
						"shapes":[
							{
								"type":"SphereColliderShape",
								"center":[
									0,
									0,
									0
								],
								"radius":0.5
							}
						],
						"isTrigger":false,
						"linearFactor":[
							1,
							1,
							1
						],
						"angularFactor":[
							1,
							1,
							1
						]
					}
				],
				"child":[]
			},
			{
				"type":"MeshSprite3D",
				"instanceID":5,
				"props":{
					"name":"Capsule",
					"active":true,
					"isStatic":false,
					"layer":0,
					"position":[
						1.77,
						4.288424,
						-9.58
					],
					"rotation":[
						0,
						0,
						0,
						-1
					],
					"scale":[
						1,
						1,
						1
					],
					"meshPath":"Library/unity default resources-Capsule.lm",
					"enableRender":true,
					"materials":[
						{
							"path":"Assets/Materials/Material.lmat"
						}
					]
				},
				"components":[
					{
						"type":"Rigidbody3D",
						"mass":1,
						"isKinematic":false,
						"restitution":0,
						"friction":0.5,
						"rollingFriction":0,
						"linearDamping":0,
						"angularDamping":0,
						"overrideGravity":false,
						"gravity":[
							0,
							0,
							0
						],
						"shapes":[
							{
								"type":"CapsuleColliderShape",
								"center":[
									0,
									0,
									0
								],
								"radius":0.5,
								"height":2,
								"orientation":1
							}
						],
						"isTrigger":false,
						"linearFactor":[
							1,
							1,
							1
						],
						"angularFactor":[
							1,
							1,
							1
						]
					}
				],
				"child":[]
			}
		]
	}
}