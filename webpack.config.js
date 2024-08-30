const path = require('path');

module.exports = {
    // Entry point for the application
    entry: './Scripts/app.jsx',

    // Output configuration
    output: {
        path: path.resolve(__dirname, 'wwwroot/js'),
        filename: 'bundle.js'
    },

    // Module rules for processing files
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-env', '@babel/preset-react']
                    }
                }
            },
			{
				test: /\.css$/, // Target CSS files
				use: ['style-loader', 'css-loader'] 
            }
        ]
    },

    // Resolve extensions for imports
    resolve: {
        extensions: ['.js', '.jsx']
    },

    // Development mode for better debugging
    mode: 'development'
};