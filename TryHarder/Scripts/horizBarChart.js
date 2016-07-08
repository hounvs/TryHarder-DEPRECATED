function drawChart(chartName, data, chartWidth) {
    var barHeight = 15,
        groupHeight = barHeight * data.series.length,
        gapBetweenGroups = 10,
        spaceForLabels = 150,
        spaceForLegend = 125;

    // Zip the series data together (first values, second values, etc.)
    var zippedData = [];
    for (var i = 0; i < data.labels.length; i++) {
        for (var j = 0; j < data.series.length; j++) {
            zippedData.push(data.series[j].values[i]);
        }
    }

    // Color scale
    // You, bronze, silver, gold, platinum, diamond, master, challenger
    var legendColors = ["#cc1616", "#8B4513", "#C0C0C0", "#DAA520", "#00deaf", "#4169E1", "#49d6ee", "#FFD700"];
    var chartHeight = barHeight * zippedData.length + gapBetweenGroups * data.labels.length;

    var x = d3.scale.linear()
        .domain([0, d3.max(zippedData)])
        .range([0, chartWidth]);

    var y = d3.scale.linear()
        .range([chartHeight + gapBetweenGroups, 0]);

    var yAxis = d3.svg.axis()
        .scale(y)
        .tickFormat('')
        .tickSize(0)
        .orient("left");

    // Specify the chart area and dimensions
    var chart = d3.select("." + chartName)
        .attr("width", spaceForLabels + chartWidth + spaceForLegend)
        .attr("height", chartHeight);

    // Create bars
    var bar = chart.selectAll("g")
        .data(zippedData)
        .enter().append("g")
        .attr("transform", function (d, i) {
            return "translate(" + spaceForLabels + "," + (i * barHeight + gapBetweenGroups * (0.5 + Math.floor(i / data.series.length))) + ")";
        });

    // Create rectangles of the correct width
    bar.append("rect")
        .attr("fill", function (d, i) { return legendColors[i % data.series.length]; })
        .attr("class", "bar")
        .attr("width", x)
        .attr("height", barHeight - 1);

    // Add text label in bar
    bar.append("text")
        .attr("class", "chartValue")
        .attr("x", function (d) { return x(d) - 3; })
        .attr("y", barHeight / 2)
        .attr("fill", "red")
        .attr("dy", ".35em")
        .text(function (d) { return d; });

    // Draw labels
    bar.append("text")
        .attr("class", "chartLabel")
        .attr("x", function (d) { return -10; })
        .attr("y", groupHeight / 2)
        .attr("dy", ".35em")
        .text(function (d, i) {
            if (i % data.series.length === 0)
                return data.labels[Math.floor(i / data.series.length)];
            else
                return ""
        });

    chart.append("g")
          .attr("class", "y axis")
          .attr("transform", "translate(" + spaceForLabels + ", " + -gapBetweenGroups / 2 + ")")
          .call(yAxis);

    // Draw legend
    var legendRectSize = 15,
        legendSpacing = 4;

    var legend = chart.selectAll('.chartLegend')
        .data(data.series)
        .enter()
        .append('g')
        .attr('transform', function (d, i) {
            var height = legendRectSize + legendSpacing;
            var offset = -gapBetweenGroups / 2;
            var horz = spaceForLabels + chartWidth + 40 - legendRectSize;
            var vert = i * height - offset;
            return 'translate(' + horz + ',' + vert + ')';
        });

    legend.append('rect')
        .attr('width', legendRectSize)
        .attr('height', legendRectSize)
        .style('fill', function (d, i) { return legendColors[i]; })
        .style('stroke', function (d, i) { return legendColors[i]; });

    legend.append('text')
        .attr('class', 'chartLegend')
        .attr('x', legendRectSize + legendSpacing)
        .attr('y', legendRectSize - legendSpacing)
        .text(function (d) { return d.label; });
}