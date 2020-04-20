varying vec3 vUv;
uniform vec3 colorA;
uniform vec3 colorB;
uniform vec3 colorC;
uniform vec3 colorD;

void main() {
  gl_FragColor = vec4(mix(colorD, colorB, vUv.x - vUv.y), 1);
  
}
