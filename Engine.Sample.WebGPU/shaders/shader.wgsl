struct VertexInput {
	@location(0) position: vec2f,
};

struct VertexOutput {
	@builtin(position) position: vec4f,
};

struct UniformValues {
	projectionMatrix: mat4x4f,
	viewMatrix: mat4x4f,
	modelMatrix: mat4x4f,
	time: f32,
};

@group(0) @binding(0) var<uniform> uniforms: UniformValues;
@group(0) @binding(1) var gradientTexture: texture_2d<f32>;

@vertex
fn vs_main(in: VertexInput) -> VertexOutput {
	var out: VertexOutput;

	out.position = uniforms.projectionMatrix * uniforms.viewMatrix * uniforms.modelMatrix * vec4f(in.position, 0.0, 1.0);

	return out;
}

@fragment
fn fs_main(in: VertexOutput) -> @location(0) vec4f {
	let color = textureLoad(gradientTexture, vec2i(in.position.xy), 0).rgb;
	
	// Apply linear color correction.
    let correctedColor = pow(color, vec3f(2.2));

	return vec4f(correctedColor, 1.0);
}
