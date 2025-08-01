struct VertexInput {
	@location(0) position: vec3f,
	@location(1) normal: vec3f,
	@location(2) color: vec3f,
};

struct VertexOutput {
	@builtin(position) position: vec4f,
	@location(0) normal: vec3f,
	@location(1) color: vec3f,
};

struct UniformValues {
	projectionMatrix: mat4x4f,
	viewMatrix: mat4x4f,
	modelMatrix: mat4x4f,
	color: vec4f,
	time: f32,
};

@group(0) @binding(0) var<uniform> uniforms: UniformValues;

@vertex
fn vs_main(in: VertexInput) -> VertexOutput {
	var out: VertexOutput;

	out.position = uniforms.projectionMatrix * uniforms.viewMatrix * uniforms.modelMatrix * vec4f(in.position, 1.0);
	out.normal = (uniforms.modelMatrix * vec4f(in.normal, 1.0)).xyz;
	out.color = in.color;

	return out;
}

@fragment
fn fs_main(in: VertexOutput) -> @location(0) vec4f {
	// Apply linear color correction.
//	let color = pow(in.color * uniforms.color.rgb, vec3f(2.2));
	let normal = normalize(in.normal);
	let lightDirection = vec3f(0.5, -0.9, 0.1);
	let lightDirection2 = vec3f(0.2, 0.4, 0.3);
	let lightColor1 = vec3f(1.0, 0.9, 0.6);
    let lightColor2 = vec3f(0.6, 0.9, 1.0);
        
	let shading1 = max(0.0, dot(lightDirection, normal));
	let shading2 = max(0.0, dot(lightDirection2, normal));
	
	let shading = shading1 * lightColor1 + shading2 * lightColor2;
	
	let color = in.color * shading;

	return vec4f(color, uniforms.color.a);
}
