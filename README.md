# Midterm Exam Practical


# Controls

1 - Enable/Disable LightSource Rotation
2 - Toggle ground color between grass and desert
3 - Enable/Disable forcefield

# Sources

https://www.deviantart.com/thegreengiddly/art/Alien-Force-Field-Texture-146051944 (alien forcefield texture)


# Explanations


Forcefield:
To get the basic forcefield effect, I used the rim lighting technique seen in class. This effect isn't enough, so I added in two other effects to bring the forcefield together.

The first effect being a scrolling texture, this was done by doing a simple texture application through the shader, and through C# code we can access the Offset property of said texture. Simply setting the x offset to the Time.time allowed us to have a scrolling texture on our forcefield!

Psuedo Code:

Shader Code
set texture in properties
fetch texture through sampler2D in CGProgram
apply texture

C#
Every frame update the offset of the texture based on Time.time
Make sure it happens in editor as well

The second effect is a little less noticable, but it simply lerps the color inside the rim lighting based on the distance from the camera. This effect adds in a nice transition from far away to closer.

Psuedo Code:
set a vector4 in properties
get vector4 in CGProgram
calculate distance from camera pos to world pos (vector4)
subtract radius value set through C#
Clamp between 0, 0.5
Apply output to the alpha
