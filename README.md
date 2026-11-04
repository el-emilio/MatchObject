AI DECLARATION CLASSWORK 19


What the code does

A boolean for each parameter is declared, a one that checks the shape, a one that checks the color, a one that checks the size and a one that checks the rotation. There are also a boolean that checks if all characteristics are selected (confirmado).

In addition, each characteristic of the figure has an array, besides the three figures being in a corner of the room.

The B button changes the option and the trigger selects the option the player wants. While pressing B the array of the options is changing the position; the booleans make sure that the steps are chosen in order.

The right trigger makes the selection of the characteristic of the shape, the left one resets everything and the boton below in the right controller is for finishing all the selection.

When the shape is selected, the bool of shapes is true and that makes the selection change to the color one, then when the color is selected the bool of color is true and that makes the code move to the rotation.

For the shape, depending the position of the array, their respective figure is translated to the position of x: 0.677, y: 1.431, z: -0203, wich is in front of the user. The color is changed with GetComponent and the size and rotation with a transform



Prompts & process

The logic of the shapes is mine and I started by writing that by myself, I needed again the AI to remember how to access to the button and the trigger of the controller, I gave it the first part of the code and ask this:

“Based on this code, I want to know how to access the buttons on a Meta Quest 3.0 controller. I don't need you to explain how to import files or how to drag and drop, since I already have the Unity VR template. Button B should cycle through the array, and one trigger should select an item while another resets it”

This gave me a full code implementation but the important part was this lines:

“public InputAction botonB = new InputAction(binding: <XRController>{RightHand}/secondaryButton");
    public InputAction gatilloElegir = new InputAction(binding: <XRController>{RightHand}/triggerPressed");
    public InputAction gatilloReiniciar = new InputAction(binding: <XRController>{LeftHand}/triggerPressed");
    public InputAction gatilloConfirmar = new InputAction(binding: <XRController>{RightHand}/gripPressed");”

With this I ask AI to repeat the logic of the shapes and check it with booleans to make it in order:

“Once you've chosen the shape, use B to cycle through the colors (Unity's primary colors, to keep it simple) and press a trigger to select it.

The same applies to size: small, large, or medium.

The same applies to rotation: Rotate 90 degrees along the x, y, or z axis.

Another trigger should allow you to reset.

Another trigger should allow you to confirm your selection.

For this, there must be Booleans. One for the shape, another for size, color, rotation, etc. As long as it isn’t selected, the Boolean will be false. Color selection cannot work if the shape Boolean isn’t “true,” and size selection cannot work if the color Boolean isn’t true.”

Some errors that I have was not adding a modular operation when passing trough the array, because it ended in a position that didn’t exist, wich caused exceptions. This was a thing I didn’t noticed and that AI explained to me
