uniform sampler2D texture1;
varying vec2 vUv;

void main() {
	vec2 a = vec2(vUv.x*1.75,vUv.y*1.75);
//	vec2 b = vec2(0.5,0.5);
//	vec2 c = vec2(mod(vUv.x,1.5),vUv.y);
//	vec2 d = vUv;
	a.x = 1.8 * mod(vUv.x,.5);
	a.y = mod(vUv.y,.50) * 1.8;

	
	gl_FragColor = texture2D(texture1,a);

}
