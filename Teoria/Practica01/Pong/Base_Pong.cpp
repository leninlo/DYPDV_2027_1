
//Base_Pong.cpp : A bouncing ball 

//#include <windows.h> //the windows include file, required by all windows applications
#include <GL/glut.h> //the glut file for windows operations
					 // it also includes gl.h and glu.h for the openGL library calls
#include <math.h>
#include <stdio.h>
#define PI 3.1415926535898 

double xpos, ypos, ydir, xdir;         // x and y position for house to be drawn
double sx, sy, squash;          // xy scale factors
double rot, rdir;             // rotation
double ball_speed;
// Variables para controlar la velocidad independientemente de los frames
double deltaTime = 0.0;
double lastTime = 0.0;
// Constantes para poder modificar las dimensiones del mundo a nuestro antojo
const int WORLD_WIDTH = 500;
const int WORLD_HEIGHT = 300;

const int CENTER_XPOS = WORLD_WIDTH / 2;
const int CENTER_YPOS = WORLD_HEIGHT / 2;

GLfloat T1[16] = { 1.,0.,0.,0.,\
				  0.,1.,0.,0.,\
				  0.,0.,1.,0.,\
				  0.,0.,0.,1. };
GLfloat S[16] = { 1.,0.,0.,0.,\
				 0.,1.,0.,0.,\
				 0.,0.,1.,0.,\
				 0.,0.,0.,1. };
GLfloat T[16] = { 1.,0.,0.,0.,\
				 0., 1., 0., 0.,\
				 0.,0.,1.,0.,\
				 0.,0.,0.,1. };



#define PI 3.1415926535898 
GLint circle_points = 100;
void MyCircle2f(GLfloat centerx, GLfloat centery, GLfloat radius) {
	GLint i;
	GLdouble angle;
	glBegin(GL_POLYGON);
	for (i = 0; i < circle_points; i++) {
		angle = 2 * PI * i / circle_points;
		glVertex2f(centerx + radius * cos(angle), centery + radius * sin(angle));
	}
	glEnd();
}

GLfloat RadiusOfBall = 7.;
// Draw the ball, centered at the origin
void draw_ball() {
	glColor3f(0.6, 0.3, 0.);
	MyCircle2f(0., 0., RadiusOfBall);

}

void Display(void)
{
	// swap the buffers
	glutSwapBuffers();

	//clear all pixels with the specified clear color
	glClear(GL_COLOR_BUFFER_BIT);
	// 160 is max X value in our world

	// Calculamos delta time.
	double currentTime = glutGet(GLUT_ELAPSED_TIME) / 1000.0;
	deltaTime = currentTime - lastTime;
	lastTime = currentTime;

	  // Shape has hit the ground! Stop moving and start squashing down and then back up 
	if (ypos == RadiusOfBall && ydir == -1) {
		sy = sy * squash;

		if (sy < 0.8)
			// reached maximum suqash, now unsquash back up 
			squash = 1.1;
		else if (sy > 1.) {
			// reset squash parameters and bounce ball back upwards
			sy = 1.;
			squash = 0.9;
			ydir = 1;
		}
		sx = 1. / sy;

		// 120 is max Y value in our world

	}
	else {
		// set Y position to increment 1.5 times the direction of the bounce
		ypos += ydir * ball_speed * deltaTime;
		xpos += xdir * ball_speed * deltaTime;
		
		if (xpos >= WORLD_WIDTH - RadiusOfBall || xpos <= RadiusOfBall) {
			xpos = CENTER_XPOS;
			ypos = CENTER_YPOS;

		}
		// If ball touches the top, change direction of ball downwards
		if (ypos >= WORLD_HEIGHT - RadiusOfBall) { // Hacemos >= ya que ypos puede ser mayor debido a que manejamos flotantes
			ypos = WORLD_HEIGHT - RadiusOfBall; // Dejamos la pelota en el top
			ydir = -1;
		}
		// If ball touches the bottom, change direction of ball upwards
		else if (ypos < RadiusOfBall) { // Lo miso que el caso anterior
			ypos = RadiusOfBall; // Dejamos la pelota en buttom
			ydir = 1;
		}
			
	}

	/*  //reset transformation state
	  glLoadIdentity();

	  // apply translation
	  glTranslatef(xpos,ypos, 0.);

	  // Translate ball back to center
	  glTranslatef(0.,-RadiusOfBall, 0.);
	  // Scale the ball about its bottom
	  glScalef(sx,sy, 1.);
	  // Translate ball up so bottom is at the origin
	  glTranslatef(0.,RadiusOfBall, 0.);
	  // draw the ball
	  draw_ball();
	*/

	//Translate the bouncing ball to its new position
	T[12] = xpos;
	T[13] = ypos;
	glLoadMatrixf(T);

	T1[13] = -RadiusOfBall;
	// Translate ball back to center
	glMultMatrixf(T1);
	S[0] = sx;
	S[5] = sy;
	// Scale the ball about its bottom
	glMultMatrixf(S);

	T1[13] = RadiusOfBall;
	// Translate ball up so bottom is at the origin

	glMultMatrixf(T1);

	draw_ball();
	glutPostRedisplay();



}


void reshape(int w, int h)
{
	// on reshape and on startup, keep the viewport to be the entire size of the window
	glViewport(0, 0, (GLsizei)w, (GLsizei)h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();

	// keep our logical coordinate system constant
	gluOrtho2D(0.0, WORLD_WIDTH, 0.0, WORLD_HEIGHT);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

}


void init(void) {
	//set the clear color
	glClearColor(0.0, 0.8, 0.0, 1.0);
	// initial position set to 0,0
	xpos = CENTER_XPOS; ypos = CENTER_YPOS; xdir = 1; ydir = 1;
	sx = 1.; sy = 1.; squash = 0.9;
	rot = 0;
	ball_speed = 120;
	// Tiempo actual
	lastTime = glutGet(GLUT_ELAPSED_TIME) / 1000.0; 

}


int main(int argc, char* argv[])
{

	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(WORLD_WIDTH + 10, WORLD_HEIGHT + 10);
	glutCreateWindow("Bouncing Ball");
	init();
	glutDisplayFunc(Display);
	glutReshapeFunc(reshape);
	glutMainLoop();

	return 1;
}
